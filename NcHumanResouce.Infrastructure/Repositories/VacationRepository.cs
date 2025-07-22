using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NcHumanResouce.Infrastructure.Mongo;
using NcHumanResource.Application.DTOs;
using NcHumanResource.Domain.Entities;
using NcHumanResource.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResouce.Infrastructure.Repositories
{
    public class VacationRepository : IVacationRepository
    {
        private readonly IMongoCollection<Employee> _collection;

        public VacationRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _collection = db.GetCollection<Employee>("Employees");
        }

        public async Task AddAsync(string employeeId, VacationRequest request)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.Push(e => e.VacationRequests, request)
                                                   .Inc(e => e.VacationUsed, request.NumberOfDays);
            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<VacationRequest>> GetAllAsync(string employeeId)
        {
            var employee = await _collection.Find(e => e.NcEmployeeID == employeeId).FirstOrDefaultAsync();
            return employee?.VacationRequests ?? new List<VacationRequest>();
        }

        public async Task UpdateAsync(string employeeId, VacationRequest updated)
        {
            var filter = Builders<Employee>.Filter.And(
                Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId),
                Builders<Employee>.Filter.ElemMatch(e => e.VacationRequests, x => x.VacationRequestId == updated.VacationRequestId)
            );

            var update = Builders<Employee>.Update.Set("VacationRequests.$", updated);
            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(string employeeId, string requestId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var employee = await _collection.Find(filter).FirstOrDefaultAsync();
            var request = employee?.VacationRequests?.FirstOrDefault(x => x.VacationRequestId == requestId);

            if (request == null) return;

            var update = Builders<Employee>.Update.PullFilter(e => e.VacationRequests,
                Builders<VacationRequest>.Filter.Eq(x => x.VacationRequestId, requestId));

            // Reverse accrual
            var pullAndAdjust = Builders<Employee>.Update.Combine(
                update,
                Builders<Employee>.Update.Inc(e => e.VacationUsed, -request.NumberOfDays)
            );

            await _collection.UpdateOneAsync(filter, pullAndAdjust);
        }

        public async Task<List<VacationRegister>> GetAllVacationRequestsAsync()
        {
            var employees = await _collection.Find(Builders<Employee>.Filter.Empty).ToListAsync();

            var allRequests = new List<VacationRegister>();

            foreach (var emp in employees)
            {
                if (emp.VacationRequests == null) continue;

                foreach (var req in emp.VacationRequests)
                {
                    allRequests.Add(new VacationRegister
                    {
                        EmployeeId = emp.NcEmployeeID,
                        EmployeeName = emp.FirstName + " " + emp.LastName,
                        VacationRequestId = req.VacationRequestId,
                        VacationType = req.VacationType,
                        Status = req.Status,
                        StartDate = req.StartDate,
                        EndDate = req.EndDate,
                        Reason = req.Reason,
                        ManagerComments = req.ManagerComments,
                        ApprovedBy = req.ApprovedBy
                    });
                }
            }

            return allRequests.OrderByDescending(r => r.StartDate).ToList();
        }

    
    }
}