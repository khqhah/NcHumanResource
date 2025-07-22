using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    public class EmploymentHistory
    {
        public DateOnly UpdateDate { get; set; }
        public DateOnly EffectiveDate { get; set; }
        public decimal SalaryAmount { get; set; }
        public String UpdateDescription { get; set; }
    }
}
