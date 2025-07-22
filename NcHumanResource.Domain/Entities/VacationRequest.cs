using NcHumanResource.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    public class VacationRequest
    {
        public string VacationRequestId { get; set; } = Guid.NewGuid().ToString();
        public VacationType VacationType { get; set; }
        public VacationStatus Status { get; set; } = VacationStatus.Requested;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public int NumberOfDays => (EndDate - StartDate).Days + 1;
        public string ManagerComments { get; set; }
        public DateTime RequestedOn { get; set; } = DateTime.UtcNow;
        public string ApprovedBy { get; set; }
    }

}
