using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Enums
{
    public enum VacationStatus
    {
        Requested = 1,
        Approved = 2,
        Rejected = 3,
        Cancelled = 4,
        Taken = 5
    }
}