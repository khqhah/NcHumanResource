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
    public class TalentRepository : ITalentRepository
    {
        private readonly IMongoCollection<Employee> _employeeCollection;

        public TalentRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _employeeCollection = db.GetCollection<Employee>("Employees");
        }

        public async Task AddTalentAsync(string employeeId, Talent talent)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.Push(e => e.Talents, talent);
            await _employeeCollection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<Talent>> GetTalentsAsync(string employeeId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var employee = await _employeeCollection.Find(filter).FirstOrDefaultAsync();
            return employee?.Talents ?? new List<Talent>();
        }

        public async Task UpdateTalentAsync(string employeeId, Talent updatedTalent)
        {
            var filter = Builders<Employee>.Filter.And(
                Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId),
                Builders<Employee>.Filter.ElemMatch(e => e.Talents, t => t.TalentId == updatedTalent.TalentId)
            );

            var update = Builders<Employee>.Update.Set("Talents.$", updatedTalent);
            await _employeeCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteTalentAsync(string employeeId, string talentId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.PullFilter(e => e.Talents,
                                Builders<Talent>.Filter.Eq(t => t.TalentId, talentId));
            await _employeeCollection.UpdateOneAsync(filter, update);
        }
    }
}
