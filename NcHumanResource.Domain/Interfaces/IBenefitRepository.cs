using NcHumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Interfaces
{
    public interface IBenefitRepository
    {
        Task AddBenefitAsync(string employeeId, Benefit benefit);
        Task<IEnumerable<Benefit>> GetBenefitsAsync(string employeeId);
        Task UpdateBenefitAsync(string employeeId, Benefit updatedBenefit);
        Task DeleteBenefitAsync(string employeeId, string benefitId);
    }

}
