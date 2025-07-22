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
    public class CertificationRepository : ICertificationRepository
    {
        private readonly IMongoCollection<Employee> _employeeCollection;

        public CertificationRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _employeeCollection = db.GetCollection<Employee>("Employees");
        }

        public async Task AddCertificationAsync(string employeeId, Certification cert)
        {
            //var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            //var update = Builders<Employee>.Update.Push(e => e.Certifications, cert);
            //await _employeeCollection.UpdateOneAsync(filter, update);


            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.Push(e => e.Certifications, cert);

            var result = await _employeeCollection.UpdateOneAsync(filter, update);

            Console.WriteLine($"Matched: {result.MatchedCount}, Modified: {result.ModifiedCount}");

        }

        public async Task<IEnumerable<Certification>> GetCertificationsAsync(string employeeId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var projection = Builders<Employee>.Projection.Include(e => e.Certifications);
            var employee = await _employeeCollection.Find(filter).FirstOrDefaultAsync();
            return employee?.Certifications ?? new List<Certification>();
        }

        public async Task UpdateCertificationAsync(string employeeId, Certification updatedCert)
        {
            var filter = Builders<Employee>.Filter.And(
                Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId),
                Builders<Employee>.Filter.ElemMatch(e => e.Certifications, c => c.CertificationId == updatedCert.CertificationId)
            );

            //var update = Builders<Employee>.Update.Set(e => e.Certifications[-1], updatedCert); // -1 = matched element
            var update = Builders<Employee>.Update.Set("Certifications.$", updatedCert);

            await _employeeCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteCertificationAsync(string employeeId, string certificationId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.PullFilter(e => e.Certifications,
                                Builders<Certification>.Filter.Eq(c => c.CertificationId, certificationId));

            await _employeeCollection.UpdateOneAsync(filter, update);
        }
    }

}
