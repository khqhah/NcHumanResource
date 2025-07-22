using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Enums
{
    public enum EmployeeCategory
    {
        [Display(Name = "Full Time")]
        FullTime,
        [Display(Name = "Part Time")]
        PartTime,
        Consultant,
        Contractor,
        [Display(Name = "Intern or Coop")]
        InternOrCoop
    }
}