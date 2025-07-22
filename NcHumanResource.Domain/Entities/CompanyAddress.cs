using NcHumanResource.Domain.Entities;
using NcHumanResources.Domain;

namespace NcHumanResources.Domain.Entities; 

  public class CompanyAddress:Address
    {
        public NcHumanResource.Shared.Enums.CompanyAddressType AddressType { get; set; }
        public DateOnly EffectiveFrom { get; set; }
        public DateOnly EffectiveUntil { get; set; }
    }