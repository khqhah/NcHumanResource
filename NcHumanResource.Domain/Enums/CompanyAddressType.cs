using System.ComponentModel.DataAnnotations;

namespace NcHumanResource.Shared.Enums;
public enum CompanyAddressType
{
    All, 
    [Display(Name = "Payroll or Billing")]
    PayrollOrBilling, 
    Notification
}