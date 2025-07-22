using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Application.DTOs
{
    public class CertificationDto
    {
        public string CertificationId { get; set; }
        public string Name { get; set; }
        public string IssuingAuthority { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpiryDate { get; set; }
    }

}
