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
    public class BenefitRepository : IBenefitRepository
    {
        private readonly IMongoCollection<Employee> _employeeCollection;

        public BenefitRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _employeeCollection = db.GetCollection<Employee>("Employees");
        }

        public async Task AddBenefitAsync(string employeeId, Benefit benefit)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.Push(e => e.Benefits, benefit);
            await _employeeCollection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<Benefit>> GetBenefitsAsync(string employeeId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var employee = await _employeeCollection.Find(filter).FirstOrDefaultAsync();
            return employee?.Benefits ?? new List<Benefit>();
        }

        public async Task UpdateBenefitAsync(string employeeId, Benefit updatedBenefit)
        {
            var filter = Builders<Employee>.Filter.And(
                Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId),
                Builders<Employee>.Filter.ElemMatch(e => e.Benefits, b => b.BenefitId == updatedBenefit.BenefitId)
            );

            var update = Builders<Employee>.Update.Set("Benefits.$", updatedBenefit);
            await _employeeCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteBenefitAsync(string employeeId, string benefitId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.PullFilter(e => e.Benefits,
                                Builders<Benefit>.Filter.Eq(b => b.BenefitId, benefitId));
            await _employeeCollection.UpdateOneAsync(filter, update);
        }
    }
}