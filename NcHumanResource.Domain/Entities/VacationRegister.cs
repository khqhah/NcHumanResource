using NcHumanResource.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    public class VacationRegister
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public string VacationRequestId { get; set; }
        public VacationType VacationType { get; set; }
        public VacationStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public string ManagerComments { get; set; }
        public string ApprovedBy { get; set; }
    }
}
