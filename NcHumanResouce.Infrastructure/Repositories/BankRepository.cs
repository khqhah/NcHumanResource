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
    public class BankRepository : IBankRepository
    {
        private readonly IMongoCollection<Employee> _collection;

        public BankRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _collection = db.GetCollection<Employee>("Employees");
        }

        public async Task AddBankAsync(string employeeId, Bank bank)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.Push(e => e.BankDetails, bank);
            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<Bank>> GetBanksAsync(string employeeId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var emp = await _collection.Find(filter).FirstOrDefaultAsync();
            return emp?.BankDetails ?? new List<Bank>();
        }

        public async Task UpdateBankAsync(string employeeId, Bank updatedBank)
        {
            var filter = Builders<Employee>.Filter.And(
                Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId),
                Builders<Employee>.Filter.ElemMatch(e => e.BankDetails, b => b.BankId == updatedBank.BankId)
            );

            var update = Builders<Employee>.Update.Set("BankDetails.$", updatedBank);
            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteBankAsync(string employeeId, string bankId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.NcEmployeeID, employeeId);
            var update = Builders<Employee>.Update.PullFilter(e => e.BankDetails,
                Builders<Bank>.Filter.Eq(b => b.BankId, bankId));
            await _collection.UpdateOneAsync(filter, update);
        }
    }

}
