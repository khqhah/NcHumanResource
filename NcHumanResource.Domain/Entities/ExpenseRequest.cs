using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    public class ExpenseRequest
    {
        public string ExpenseRequestId { get; set; } = Guid.NewGuid().ToString();
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; } // e.g., Travel, Lodging, Meals, etc.
        public string ReceiptUrl { get; set; } // optional, if uploaded to storage
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
        public string ManagerComments { get; set; }
    }
}