using NcHumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Interfaces
{
    public interface ITravelRequestRepository
    {
        Task AddAsync(string employeeId, TravelRequest request);
        Task<IEnumerable<TravelRequest>> GetAllAsync(string employeeId);
        Task UpdateAsync(string employeeId, TravelRequest request);
        Task DeleteAsync(string employeeId, string requestId);
    }
}