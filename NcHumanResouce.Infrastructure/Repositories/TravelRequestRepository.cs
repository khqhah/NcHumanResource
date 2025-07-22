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
    public class TravelRequestRepository : ITravelRequestRepository
    {
        private readonly IMongoCollection<Employee> _collection;

        public TravelRequestRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _collection = db.GetCollection<Employee>("Employees");
        }

        public async Task AddAsync(string employeeId, TravelRequest request)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.Push(e => e.TravelRequests, request);
            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<TravelRequest>> GetAllAsync(string employeeId)
        {
            var employee = await _collection.Find(e => e.NcEmployeeID == employeeId).FirstOrDefaultAsync();
            return employee?.TravelRequests ?? new List<TravelRequest>();
        }

        public async Task UpdateAsync(string employeeId, TravelRequest request)
        {
            var filter = Builders<Employee>.Filter.And(
                Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId),
                Builders<Employee>.Filter.ElemMatch(e => e.TravelRequests, r => r.TravelRequestId == request.TravelRequestId)
            );

            var update = Builders<Employee>.Update.Set("TravelRequests.$", request);
            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(string employeeId, string requestId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.PullFilter(e => e.TravelRequests,
                            Builders<TravelRequest>.Filter.Eq(r => r.TravelRequestId, requestId));
            await _collection.UpdateOneAsync(filter, update);
        }
    }

}
