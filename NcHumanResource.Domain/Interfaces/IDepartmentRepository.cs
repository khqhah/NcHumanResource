using NcHumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Interfaces
{
    public interface IDepartmentRepository
    {
        Task AddAsync(Department department);
        Task<List<Department>> GetAllAsync();
        Task DeleteAsync(string DepartmentID);
        Task<Department> GetByIdAsync(string id);
        Task UpdateAsync(string id, Department department);

    }
}
