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
    public class EmployeePreferenceRepository : IEmployeePreferenceRepository
    {
        private readonly IMongoCollection<Employee> _employeeCollection;

        public EmployeePreferenceRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _employeeCollection = db.GetCollection<Employee>("Employees");
        }

        public async Task AddPreferenceAsync(string employeeId, EmployeePreference preference)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.Push(e => e.Preferences, preference);
            await _employeeCollection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<EmployeePreference>> GetPreferencesAsync(string employeeId)
        {
            var employee = await _employeeCollection.Find(e => e.NcEmployeeID == employeeId).FirstOrDefaultAsync();
            return employee?.Preferences ?? new List<EmployeePreference>();
        }

        public async Task UpdatePreferenceAsync(string employeeId, EmployeePreference updated)
        {
            var filter = Builders<Employee>.Filter.And(
                Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId),
                Builders<Employee>.Filter.ElemMatch(e => e.Preferences, p => p.Id == updated.Id)
            );

            var update = Builders<Employee>.Update.Set("Preferences.$", updated);
            await _employeeCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeletePreferenceAsync(string employeeId, string preferenceId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.PullFilter(e => e.Preferences,
                            Builders<EmployeePreference>.Filter.Eq(p => p.Id, preferenceId));
            await _employeeCollection.UpdateOneAsync(filter, update);
        }
    }
}
