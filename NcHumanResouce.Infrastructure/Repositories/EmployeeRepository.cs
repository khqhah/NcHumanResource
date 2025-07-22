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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMongoCollection<Employee> _collection;
        public EmployeeRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<Employee>("Employees");
        }
        public async Task AddAsync(Employee employee)
        {
            await _collection.InsertOneAsync(employee);
        }

        public async Task DeleteAsync(string ncEmployeeId)
        {
            var filter = Builders<Employee>.Filter.Eq(d => d.NcEmployeeID, ncEmployeeId);
            await _collection.DeleteOneAsync(filter);
        }

        public Task<bool> ExistsAsync(string ncEmployeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(string ncEmployeeId)
        {
            var filter = Builders<Employee>.Filter.Eq(d => d.NcEmployeeID, ncEmployeeId);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string ncEmployeeId, Employee updatedEmployee)
        {
            var filter = Builders<Employee>.Filter.Eq(d => d.NcEmployeeID, ncEmployeeId);
            await _collection.ReplaceOneAsync(filter, updatedEmployee);
        }

        public async Task UpdateDepartmentAsync(string ncEmployeeId, string departmentId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, ncEmployeeId);
            var update = Builders<Employee>.Update.Set(e => e.Department, departmentId);

            await _collection.UpdateOneAsync(filter, update);
        }

    }
}
