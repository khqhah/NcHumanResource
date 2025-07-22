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
    public class BenefitService
    {
        private readonly IBenefitRepository _repo;

        public BenefitService(IBenefitRepository repo)
        {
            _repo = repo;
        }

        public async Task AddBenefitAsync(string employeeId, BenefitDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.BenefitId))
                throw new ArgumentException("BenefitId is required.");

            var existing = await _repo.GetBenefitsAsync(employeeId);
            if (existing.Any(b => b.BenefitId == dto.BenefitId))
                throw new InvalidOperationException("Benefit already exists.");
            var benefit = new Benefit
            {
                BenefitId = dto.BenefitId,
                Name = dto.Name,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };
            await _repo.AddBenefitAsync(employeeId, benefit);
        }
        public async Task<IEnumerable<Benefit>> GetBenefitsAsync(string employeeId)
        {
            return await _repo.GetBenefitsAsync(employeeId);
        }
        public async Task UpdateBenefitAsync(string employeeId, BenefitDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.BenefitId))
                throw new ArgumentException("BenefitId is required.");

            var updated = new Benefit
            {
                BenefitId = dto.BenefitId,
                Name = dto.Name,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };

            await _repo.UpdateBenefitAsync(employeeId, updated);
        }
        public async Task DeleteBenefitAsync(string employeeId, string benefitId)
        {
            await _repo.DeleteBenefitAsync(employeeId, benefitId);
        }
    }
}