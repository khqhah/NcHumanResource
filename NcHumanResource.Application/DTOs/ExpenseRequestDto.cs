using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Application.DTOs
{
    public class ExpenseRequestDto
    {
        public string ExpenseRequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public string ReceiptUrl { get; set; }
        public string Status { get; set; }
        public string ManagerComments { get; set; }
    }
}