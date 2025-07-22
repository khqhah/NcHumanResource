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
    public class TravelRequestService
    {
        private readonly ITravelRequestRepository _repo;

        public TravelRequestService(ITravelRequestRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(string employeeId, TravelRequestDto dto)
        {
            if (dto.StartDate >= dto.EndDate)
                throw new ArgumentException("End date must be after start date.");

            var model = new TravelRequest
            {
                TravelRequestId = Guid.NewGuid().ToString(),
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Destination = dto.Destination,
                Purpose = dto.Purpose,
                Status = "Pending"
            };

            await _repo.AddAsync(employeeId, model);
        }

        public async Task<IEnumerable<TravelRequest>> GetAllAsync(string employeeId)
            => await _repo.GetAllAsync(employeeId);

        public async Task UpdateAsync(string employeeId, TravelRequestDto dto)
        {
            var model = new TravelRequest
            {
                TravelRequestId = dto.TravelRequestId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Destination = dto.Destination,
                Purpose = dto.Purpose,
                Status = dto.Status,
                ManagerComments = dto.ManagerComments
            };

            await _repo.UpdateAsync(employeeId, model);
        }

        public async Task DeleteAsync(string employeeId, string requestId)
            => await _repo.DeleteAsync(employeeId, requestId);
    }

}
