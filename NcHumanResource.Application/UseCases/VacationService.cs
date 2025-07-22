using NcHumanResource.Application.DTOs;
using NcHumanResource.Domain.Entities;
using NcHumanResource.Domain.Enums;
using NcHumanResource.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Application.UseCases
{
    public class VacationService
    {
        private readonly IVacationRepository _repo;

        public VacationService(IVacationRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(string employeeId, VacationRequestDto dto)
        {
            var model = new VacationRequest
            {
                VacationRequestId = dto.VacationRequestId ?? Guid.NewGuid().ToString(),
                VacationType = dto.VacationType,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Reason = dto.Reason,
                Status = VacationStatus.Requested,
                ManagerComments = dto.ManagerComments, 
                ApprovedBy = dto.ApprovedBy
            };

            // Validation
            if (model.StartDate > model.EndDate)
                throw new ArgumentException("Start date cannot be after end date.");

            if (model.NumberOfDays > 21)
                throw new ArgumentException("Vacation request exceeds 3-week limit.");

            await _repo.AddAsync(employeeId, model);
        }

        public async Task<IEnumerable<VacationRequest>> GetAllAsync(string employeeId)
            => await _repo.GetAllAsync(employeeId);

        public async Task UpdateAsync(string employeeId, VacationRequestDto dto)
        {
            var model = new VacationRequest
            {
                VacationRequestId = dto.VacationRequestId,
                VacationType = dto.VacationType,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Reason = dto.Reason,
                Status = dto.Status,
                ManagerComments = dto.ManagerComments,
                ApprovedBy = dto.ApprovedBy
            };

            await _repo.UpdateAsync(employeeId, model);
        }

        public async Task DeleteAsync(string employeeId, string requestId)
            => await _repo.DeleteAsync(employeeId, requestId);

        public Task<List<VacationRegister>> GetVacationRegisterAsync()
       => _repo.GetAllVacationRequestsAsync();
    }

}
