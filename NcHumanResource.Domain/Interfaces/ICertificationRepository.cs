using NcHumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Interfaces
{
    public interface ICertificationRepository
    {
        Task AddCertificationAsync(string employeeId, Certification certification);
        Task<IEnumerable<Certification>> GetCertificationsAsync(string employeeId);
        Task UpdateCertificationAsync(string employeeId, Certification updatedCertification);
        Task DeleteCertificationAsync(string employeeId, string certificationId);
    }
}
