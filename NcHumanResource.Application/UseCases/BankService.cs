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
               Id = dto.Id,
               PreferredPaymentMethod = dto.PreferredPaymentMethod,
               WireTransfer = dto.WireTransfer,
               Cheque = dto.Cheque,
               DirectDeposit = dto.DirectDeposit,
               ETransfer = dto.ETransfer
            };
            await _repo.AddBankAsync(employeeId, bank);
        }

        public async Task<IEnumerable<Bank>> GetBanksAsync(string employeeId)
            => await _repo.GetBanksAsync(employeeId);

        public async Task UpdateBankAsync(string employeeId, BankDto dto)
        {
            var updated = new Bank
            {
                Id = dto.Id,
                PreferredPaymentMethod = dto.PreferredPaymentMethod,
                WireTransfer = dto.WireTransfer,
                Cheque = dto.Cheque,
                DirectDeposit = dto.DirectDeposit,
                ETransfer = dto.ETransfer
            };
            await _repo.UpdateBankAsync(employeeId, updated);
        }

        public async Task DeleteBankAsync(string employeeId, string bankId)
            => await _repo.DeleteBankAsync(employeeId, bankId);
    }
}