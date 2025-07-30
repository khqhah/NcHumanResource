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
    public class EmployeePreferenceService
    {
        private readonly IEmployeePreferenceRepository _repo;

        public EmployeePreferenceService(IEmployeePreferenceRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(string employeeId, EmployeePreferenceDto dto)
        {
            var pref = new EmployeePreference
            {
                Id = dto.Id ?? Guid.NewGuid().ToString(),
                RemoteWorkPreferred = dto.RemoteWorkPreferred,
                PreferredWorkingHours = dto.PreferredWorkingHours,
                CommunicationPreference = dto.CommunicationPreference,
                TimeZone = dto.TimeZone,
                CreatedAt = DateTime.UtcNow
            };

            await _repo.AddPreferenceAsync(employeeId, pref);
        }

        public async Task<IEnumerable<EmployeePreference>> GetAsync(string employeeId)
            => await _repo.GetPreferencesAsync(employeeId);

        public async Task UpdateAsync(string employeeId, EmployeePreferenceDto dto)
        {
            var updated = new EmployeePreference
            {
                Id = dto.Id,
                RemoteWorkPreferred = dto.RemoteWorkPreferred,
                PreferredWorkingHours = dto.PreferredWorkingHours,
                CommunicationPreference = dto.CommunicationPreference,
                TimeZone = dto.TimeZone,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = DateTime.UtcNow
            };

            await _repo.UpdatePreferenceAsync(employeeId, updated);
        }

        public async Task DeleteAsync(string employeeId, string preferenceId)
            => await _repo.DeletePreferenceAsync(employeeId, preferenceId);
    }
}
