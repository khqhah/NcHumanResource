using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    public class TravelRequest
    {
        public string TravelRequestId { get; set; }// = Guid.NewGuid().ToString();
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Destination { get; set; }
        public string Purpose { get; set; } // e.g., client meeting, training
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected, Cancelled
        public string ManagerComments { get; set; }
    }

}
