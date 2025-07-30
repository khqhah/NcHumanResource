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
    public class AnnualReviewRepository : IAnnualReviewRepository
    {
        private readonly IMongoCollection<Employee> _employeeCollection;

        public AnnualReviewRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _employeeCollection = db.GetCollection<Employee>("Employees");
        }

        public async Task AddReviewAsync(string employeeId, AnnualReview review)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.Push(e => e.AnnualReviews, review);
            await _employeeCollection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<AnnualReview>> GetReviewsAsync(string employeeId)
        {
            var employee = await _employeeCollection.Find(e => e.NcEmployeeID == employeeId).FirstOrDefaultAsync();
            return employee?.AnnualReviews ?? new List<AnnualReview>();
        }

        public async Task UpdateReviewAsync(string employeeId, AnnualReview updated)
        {
            var filter = Builders<Employee>.Filter.And(
                Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId),
                Builders<Employee>.Filter.ElemMatch(e => e.AnnualReviews, r => r.Id == updated.Id)
            );

            var update = Builders<Employee>.Update.Set("AnnualReviews.$", updated);
            await _employeeCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteReviewAsync(string employeeId, string reviewId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.PullFilter(e => e.AnnualReviews,
                Builders<AnnualReview>.Filter.Eq(r => r.Id, reviewId));

            await _employeeCollection.UpdateOneAsync(filter, update);
        }
    }
}
