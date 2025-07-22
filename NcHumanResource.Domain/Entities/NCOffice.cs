using NcHumanResources.Domain.Entities;

namespace NcHumanResource.Domain.Entities; 
public class NCOffice
{
    public string OfficeDesignation { get; set; }
    public string OfficeIdentifier { get; set; }
    public OfficeAddress OfficeAddress { get; set; }
}
