using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Application.DTOs
{
    public class TalentDto
    {
        public string TalentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProficiencyLevel { get; set; }
    }

}
