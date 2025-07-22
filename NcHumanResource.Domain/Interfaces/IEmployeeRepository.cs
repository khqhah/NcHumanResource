using NcHumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(string ncEmployeeId);
        Task AddAsync(Employee employee);
        Task UpdateAsync(string ncEmployeeId, Employee updatedEmployee);
        Task DeleteAsync(string ncEmployeeId);
        Task<bool> ExistsAsync(string ncEmployeeId);
        Task UpdateDepartmentAsync(string ncEmployeeId, string DepartmentID);

    }
}
