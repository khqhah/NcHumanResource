using NcHumanResource.Application.DTOs;
using NcHumanResource.Domain.Entities;
using NcHumanResource.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Application.UseCases
{
    public class ExpenseRequestService
    {
        private readonly IExpenseRequestRepository _repo;

        public ExpenseRequestService(IExpenseRequestRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(string employeeId, ExpenseRequestDto dto)
        {
            if (dto.Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            var model = new ExpenseRequest
            {
                ExpenseRequestId = Guid.NewGuid().ToString(),
                Description = dto.Description,
                Amount = dto.Amount,
                Category = dto.Category,
                ReceiptUrl = dto.ReceiptUrl,
                Status = "Pending"
            };

            await _repo.AddAsync(employeeId, model);
        }

        public async Task<IEnumerable<ExpenseRequest>> GetAllAsync(string employeeId)
            => await _repo.GetAllAsync(employeeId);

        public async Task UpdateAsync(string employeeId, ExpenseRequestDto dto)
        {
            var model = new ExpenseRequest
            {
                ExpenseRequestId = dto.ExpenseRequestId,
                Description = dto.Description,
                Amount = dto.Amount,
                Category = dto.Category,
                ReceiptUrl = dto.ReceiptUrl,
                Status = dto.Status,
                ManagerComments = dto.ManagerComments,
                RequestDate = dto.RequestDate
            };

            await _repo.UpdateAsync(employeeId, model);
        }

        public async Task DeleteAsync(string employeeId, string requestId)
            => await _repo.DeleteAsync(employeeId, requestId);
    }

}
