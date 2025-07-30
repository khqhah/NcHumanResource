using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Application.DTOs
{
    public class AnnualReviewDto
    {
        public string Id { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Reviewer { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
    }
}
