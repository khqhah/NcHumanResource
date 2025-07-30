using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Application.DTOs
{
    public class EmployeePreferenceDto
    {
        public string Id { get; set; }
        public bool RemoteWorkPreferred { get; set; }
        public string PreferredWorkingHours { get; set; }
        public string CommunicationPreference { get; set; }
        public string TimeZone { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
