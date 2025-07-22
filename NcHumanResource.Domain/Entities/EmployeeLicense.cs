

namespace NcHumanResource.Domain.Entities; 
public class EmployeeLicense
{
    public LicenseType LicenseType { get; set; }
    public IssuingOrganization IssuingOrganization { get; set; }
    public string Country {get; set;}
    public string ProvinceOrState{get; set;}
    public DateOnly MemberSince { get; set; }
    public bool IsActive { get; set; }
    
}

