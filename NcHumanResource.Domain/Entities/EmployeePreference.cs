using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    public class EmployeePreference
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool RemoteWorkPreferred { get; set; }
        public string PreferredWorkingHours { get; set; }  // e.g., "9am-5pm"
        public string CommunicationPreference { get; set; } // e.g., "Email", "Slack"
        public string TimeZone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}