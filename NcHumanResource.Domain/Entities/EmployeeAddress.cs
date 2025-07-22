using NcHumanResource.Domain.Entities;

namespace NcHumanResource.Domain.Entities; 

  public class EmployeeAddress:Address
    {
        public EmployeeAddressType AddressType { get; set; }
        public DateOnly EffectiveFrom { get; set; }
        public DateOnly EffectiveUntil { get; set; }
    }