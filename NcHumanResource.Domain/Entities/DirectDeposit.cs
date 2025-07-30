using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    public class DirectDeposit
    {
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string TransitNumber { get; set; }
        public string InstitutionNumber { get; set; }
    }

}
