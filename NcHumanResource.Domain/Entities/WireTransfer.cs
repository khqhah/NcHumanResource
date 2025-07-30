using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    public class WireTransfer
    {
        public string BankName { get; set; }
        public string SWIFTCode { get; set; }
        public string IBAN { get; set; }
        public string AccountNumber { get; set; }
    }

}
