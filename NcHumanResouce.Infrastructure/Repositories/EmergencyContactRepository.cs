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
    public class EmergencyContactRepository : IEmergencyContactRepository
    {
        private readonly IMongoCollection<Employee> _employeeCollection;

        public EmergencyContactRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _employeeCollection = database.GetCollection<Employee>("Employees");
        }

        public async Task AddEmergencyContactAsync(string employeeId, EmergencyContact contact)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.Push(e => e.EmergencyContacts, contact);
            await _employeeCollection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<EmergencyContact>> GetEmergencyContactsAsync(string employeeId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var employee = await _employeeCollection.Find(filter).FirstOrDefaultAsync();
            return employee?.EmergencyContacts ?? new List<EmergencyContact>();
        }

        public async Task UpdateEmergencyContactAsync(string employeeId, EmergencyContact updatedContact)
        {
            var filter = Builders<Employee>.Filter.And(
                Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId),
                Builders<Employee>.Filter.ElemMatch(e => e.EmergencyContacts, c => c.ContactId == updatedContact.ContactId)
            );

            //var update = Builders<Employee>.Update.Set(e => e.EmergencyContacts[-1], updatedContact); // -1 refers to matched array element
            var update = Builders<Employee>.Update.Set("EmergencyContacts.$", updatedContact);
            await _employeeCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteEmergencyContactAsync(string employeeId, string contactId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.PullFilter(
                e => e.EmergencyContacts,
                c => c.ContactId == contactId
            );

            await _employeeCollection.UpdateOneAsync(filter, update);
        }
    }
}