using NcHumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Interfaces
{
    public interface IVacationRepository
    {
        Task AddAsync(string employeeId, VacationRequest request);
        Task<IEnumerable<VacationRequest>> GetAllAsync(string employeeId);
        Task UpdateAsync(string employeeId, VacationRequest updated);
        Task DeleteAsync(string employeeId, string requestId);
        Task<List<VacationRegister>> GetAllVacationRequestsAsync();

    }
}