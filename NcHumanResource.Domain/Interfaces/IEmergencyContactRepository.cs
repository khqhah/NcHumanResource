using NcHumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Interfaces
{
    public interface IEmergencyContactRepository
    {
        Task AddEmergencyContactAsync(string employeeId, EmergencyContact contact);
        Task<IEnumerable<EmergencyContact>> GetEmergencyContactsAsync(string employeeId);
        Task UpdateEmergencyContactAsync(string employeeId, EmergencyContact updatedContact);
        Task DeleteEmergencyContactAsync(string employeeId, string contactId);
    }
}
