using NcHumanResource.Domain.Entities;
using NcHumanResource.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Application.DTOs
{
    public class BankDto
    {
        public string Id { get; set; }
        public PaymentMethod PreferredPaymentMethod { get; set; }
        public DirectDeposit? DirectDeposit { get; set; }
        public ETransfer? ETransfer { get; set; }
        public WireTransfer? WireTransfer { get; set; }
        public Cheque? Cheque { get; set; }
    }

}
