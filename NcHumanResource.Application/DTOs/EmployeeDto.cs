using NcHumanResource.Domain.Entities;
using NcHumanResource.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Application.DTOs
{
    public class EmployeeDto
    {
        public string NcEmployeeID { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitials { get; set; }
        public string LastName { get; set; }
        public ICollection<EmployeeAddress> Addresses { get; set; }
        public string Department { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public decimal SalaryAmount { get; set; }
        public SalaryType SalaryType { get; set; }
        public PaymentFrequency PaymentFrequency { get; set; }
        public EmploymentHistory EmploymentHistory { get; set; }
        public decimal AnnualSalary { get; set; }
        public string Designation { get; set; }
        public EmployeeCategory EmployeeType { get; set; }
        public bool IsArchived { get; set; }
        public bool IsOncall { get; set; }
        public bool IsRemote { get; set; }
        public DateOnly FirstDay { get; set; }
        public DateOnly LastDay { get; set; }
        public DateOnly TerminationDate { get; set; }
        public DateOnly RehireDate { get; set; }
        public string WorkEmail { get; set; }
        public string PersonalEmail { get; set; }
        public string CellNumber { get; set; }
        public string WorkNumber { get; set; }
        public bool IsCellNumberOnBusinessCard { get; set; }
        public bool RequiresBusinessCard { get; set; }
        public NCOffice PrimaryNCOffice { get; set; }
        public double VacationRate { get; set; }
        public AccessCard AccessCard { get; set; }
        public ICollection<EmployeeLicense> Licenses { get; set; }
        public bool IsContractSigned { get; set; }
        public DateOnly ContractSignatureDate { get; set; }
    }
}
