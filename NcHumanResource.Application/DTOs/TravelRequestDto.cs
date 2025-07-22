using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Application.DTOs
{
    public class TravelRequestDto
    {
        public string TravelRequestId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Destination { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; }
        public string ManagerComments { get; set; }
    }
}