using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NcHumanResouce.Infrastructure.Mongo;
using NcHumanResource.Domain.Entities;
using NcHumanResource.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResouce.Infrastructure.Repositories
{
    public class ExpenseRequestRepository : IExpenseRequestRepository
    {
        private readonly IMongoCollection<Employee> _collection;

        public ExpenseRequestRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _collection = db.GetCollection<Employee>("Employees");
        }

        public async Task AddAsync(string employeeId, ExpenseRequest request)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.Push(e => e.ExpenseRequests, request);
            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<ExpenseRequest>> GetAllAsync(string employeeId)
        {
            var employee = await _collection.Find(e => e.NcEmployeeID == employeeId).FirstOrDefaultAsync();
            return employee?.ExpenseRequests ?? new List<ExpenseRequest>();
        }

        public async Task UpdateAsync(string employeeId, ExpenseRequest request)
        {
            var filter = Builders<Employee>.Filter.And(
                Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId),
                Builders<Employee>.Filter.ElemMatch(e => e.ExpenseRequests, r => r.ExpenseRequestId == request.ExpenseRequestId)
            );

            var update = Builders<Employee>.Update.Set("ExpenseRequests.$", request);
            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(string employeeId, string requestId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.PullFilter(e => e.ExpenseRequests,
                            Builders<ExpenseRequest>.Filter.Eq(r => r.ExpenseRequestId, requestId));
            await _collection.UpdateOneAsync(filter, update);
        }
    }

}
