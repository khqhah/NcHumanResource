using MongoDB.Bson.Serialization.Attributes;
using NcHumanResource.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class Employee
    {
        public string NcEmployeeID { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitials { get; set; }
        public string LastName { get; set; }
        public ICollection<EmployeeAddress> Addresses { get; set; }
        public ICollection<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();
        public ICollection<Bank> BankDetails { get; set; } = new List<Bank>();
        public ICollection<EmployeeDocument> Documents { get; set; } = new List<EmployeeDocument>();

        public ICollection<Certification> Certifications { get; set; } = new List<Certification>();
        public ICollection<Talent> Talents { get; set; } = new List<Talent>();

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

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        public ICollection<Benefit> Benefits { get; set; } = new List<Benefit>();
        public ICollection<TodoItem> TodoList { get; set; } = new List<TodoItem>();

        public EmployeeStatus Status { get; set; }

        public ICollection<VacationRequest> VacationRequests { get; set; } = new List<VacationRequest>();

        public double VacationAccrued { get; set; } = 0;
        public double VacationUsed { get; set; } = 0;
        public ICollection<ExpenseRequest> ExpenseRequests { get; set; } = new List<ExpenseRequest>();
        public ICollection<TravelRequest> TravelRequests { get; set; } = new List<TravelRequest>();

    }
}
