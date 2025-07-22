using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    public class Bank
    {
        public string BankId { get; set; }
        public string BankName { get; set; }
        public string AccountTitle { get; set; }
        public string AccountNumber { get; set; }
        public string IBAN { get; set; }
        public string BranchCode { get; set; }
        public string BranchAddress { get; set; }
        public string SwiftCode { get; set; }
    }

}
