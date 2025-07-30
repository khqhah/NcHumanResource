using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    public class AnnualReview
    {
        public string Id { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Reviewer { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; } // 1–5 or custom scale
    }
}
