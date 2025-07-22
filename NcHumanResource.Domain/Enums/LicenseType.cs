using System.ComponentModel.DataAnnotations;

public enum LicenseType
{
    [Display(Name = "Professional Member")]
    ProfessionMember,
    [Display(Name = "Professional Licensee")]
    ProfessionalLicensee,
    [Display(Name = "Member-in-Training")]
    MemberInTraining
}
