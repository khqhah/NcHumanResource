using NcHumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Interfaces
{
    public interface IEmployeePreferenceRepository
    {
        Task AddPreferenceAsync(string employeeId, EmployeePreference preference);
        Task<IEnumerable<EmployeePreference>> GetPreferencesAsync(string employeeId);
        Task UpdatePreferenceAsync(string employeeId, EmployeePreference updated);
        Task DeletePreferenceAsync(string employeeId, string preferenceId);
    }
}
