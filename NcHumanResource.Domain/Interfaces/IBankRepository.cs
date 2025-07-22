using NcHumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Interfaces
{
    public interface IBankRepository
    {
        Task AddBankAsync(string employeeId, Bank bank);
        Task<IEnumerable<Bank>> GetBanksAsync(string employeeId);
        Task UpdateBankAsync(string employeeId, Bank updatedBank);
        Task DeleteBankAsync(string employeeId, string bankId);
    }
}
