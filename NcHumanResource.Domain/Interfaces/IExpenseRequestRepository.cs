using NcHumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Interfaces
{
    public interface IExpenseRequestRepository
    {
        Task AddAsync(string employeeId, ExpenseRequest request);
        Task<IEnumerable<ExpenseRequest>> GetAllAsync(string employeeId);
        Task UpdateAsync(string employeeId, ExpenseRequest request);
        Task DeleteAsync(string employeeId, string requestId);
    }
}