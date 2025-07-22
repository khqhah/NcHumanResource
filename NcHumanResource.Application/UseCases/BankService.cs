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
    public class BankService
    {
        private readonly IBankRepository _repo;

        public BankService(IBankRepository repo)
        {
            _repo = repo;
        }

        public async Task AddBankAsync(string employeeId, BankDto dto)
        {
            var bank = new Bank
            {
                BankId = dto.BankId,
                BankName = dto.BankName,
                AccountTitle = dto.AccountTitle,
                AccountNumber = dto.AccountNumber,
                IBAN = dto.IBAN,
                BranchCode = dto.BranchCode,
                BranchAddress = dto.BranchAddress,
                SwiftCode = dto.SwiftCode
            };
            await _repo.AddBankAsync(employeeId, bank);
        }

        public async Task<IEnumerable<Bank>> GetBanksAsync(string employeeId)
            => await _repo.GetBanksAsync(employeeId);

        public async Task UpdateBankAsync(string employeeId, BankDto dto)
        {
            var updated = new Bank
            {
                BankId = dto.BankId,
                BankName = dto.BankName,
                AccountTitle = dto.AccountTitle,
                AccountNumber = dto.AccountNumber,
                IBAN = dto.IBAN,
                BranchCode = dto.BranchCode,
                BranchAddress = dto.BranchAddress,
                SwiftCode = dto.SwiftCode
            };
            await _repo.UpdateBankAsync(employeeId, updated);
        }

        public async Task DeleteBankAsync(string employeeId, string bankId)
            => await _repo.DeleteBankAsync(employeeId, bankId);
    }
}