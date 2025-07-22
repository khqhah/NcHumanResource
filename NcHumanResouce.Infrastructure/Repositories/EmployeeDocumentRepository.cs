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
    public class EmployeeDocumentRepository : IEmployeeDocumentRepository
    {
        private readonly IMongoCollection<Employee> _collection;

        public EmployeeDocumentRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _collection = db.GetCollection<Employee>("Employees");
        }

        public async Task AddDocumentAsync(string employeeId, EmployeeDocument document)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.Push(e => e.Documents, document);
            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<EmployeeDocument>> GetDocumentsAsync(string employeeId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var emp = await _collection.Find(filter).FirstOrDefaultAsync();
            return emp?.Documents ?? new List<EmployeeDocument>();
        }

        public async Task UpdateDocumentAsync(string employeeId, EmployeeDocument updatedDoc)
        {
            var filter = Builders<Employee>.Filter.And(
                Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId),
                Builders<Employee>.Filter.ElemMatch(e => e.Documents, d => d.DocumentId == updatedDoc.DocumentId)
            );

            var update = Builders<Employee>.Update.Set("Documents.$", updatedDoc);
            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteDocumentAsync(string employeeId, string documentId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.PullFilter(e => e.Documents,
                Builders<EmployeeDocument>.Filter.Eq(d => d.DocumentId, documentId));
            await _collection.UpdateOneAsync(filter, update);
        }
    }

}
