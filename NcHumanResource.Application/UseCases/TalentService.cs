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
    public class TalentService
    {
        private readonly ITalentRepository _repo;

        public TalentService(ITalentRepository repo)
        {
            _repo = repo;
        }

        public async Task AddTalentAsync(string employeeId, TalentDto dto)
        {
            if (string.IsNullOrWhiteSpace(employeeId) || dto == null)
                throw new ArgumentException("Employee ID or talent data is invalid.");

            var existing = await _repo.GetTalentsAsync(employeeId);
            if (existing.Any(t => t.TalentId == dto.TalentId))
                throw new InvalidOperationException("Talent already exists.");

            var talent = new Talent
            {
                TalentId = dto.TalentId,
                Name = dto.Name,
                Description = dto.Description,
                ProficiencyLevel = dto.ProficiencyLevel
            };

            await _repo.AddTalentAsync(employeeId, talent);
        }

        public async Task<IEnumerable<Talent>> GetTalentsAsync(string employeeId)
        {
            return await _repo.GetTalentsAsync(employeeId);
        }

        public async Task UpdateTalentAsync(string employeeId, TalentDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TalentId))
                throw new ArgumentException("Talent ID is required.");

            var updated = new Talent
            {
                TalentId = dto.TalentId,
                Name = dto.Name,
                Description = dto.Description,
                ProficiencyLevel = dto.ProficiencyLevel
            };

            await _repo.UpdateTalentAsync(employeeId, updated);
        }

        public async Task DeleteTalentAsync(string employeeId, string talentId)
        {
            await _repo.DeleteTalentAsync(employeeId, talentId);
        }
    }

}
