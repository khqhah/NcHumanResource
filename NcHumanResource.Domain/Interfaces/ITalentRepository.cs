using NcHumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Interfaces
{
    public interface ITalentRepository
    {
        Task AddTalentAsync(string employeeId, Talent talent);
        Task<IEnumerable<Talent>> GetTalentsAsync(string employeeId);
        Task UpdateTalentAsync(string employeeId, Talent updatedTalent);
        Task DeleteTalentAsync(string employeeId, string talentId);
    }
}
