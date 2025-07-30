using NcHumanResource.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    public class Bank
    {
        public string Id { get; set; }
        public PaymentMethod PreferredPaymentMethod { get; set; }
        public DirectDeposit? DirectDeposit { get; set; }
        public ETransfer? ETransfer { get; set; }
        public WireTransfer? WireTransfer { get; set; }
        public Cheque? Cheque { get; set; }
    }

}
