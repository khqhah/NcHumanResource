using NcHumanResource.Domain.Entities;


namespace NcHumanResources.Domain.Entities; 

  public class OfficeAddress:Address
    {
        public NcHumanResource.Shared.Enums.OfficeAddressType AddressType { get; set; }
        public DateOnly EffectiveFrom { get; set; }
        public DateOnly EffectiveUntil { get; set; }
    }