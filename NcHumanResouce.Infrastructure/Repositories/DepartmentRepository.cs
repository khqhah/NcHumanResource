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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IMongoCollection<Department> _collection;

        public DepartmentRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<Department>("Departments");
        }

        public async Task AddAsync(Department department)
        {            
            await _collection.InsertOneAsync(department);
        }

        public async Task DeleteAsync(string DepartmentID)
        {
            var filter = Builders<Department>.Filter.Eq(d => d.DepartmentID, DepartmentID);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
        public async Task<Department> GetByIdAsync(string id)
        {
            var filter = Builders<Department>.Filter.Eq(d => d.DepartmentID, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task UpdateAsync(string id, Department department)
        {
            var filter = Builders<Department>.Filter.Eq(d => d.DepartmentID, id);
            await _collection.ReplaceOneAsync(filter, department);
        }

    }
}
