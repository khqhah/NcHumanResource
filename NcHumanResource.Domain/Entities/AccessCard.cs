
namespace NcHumanResource.Domain.Entities; 
public class AccessCard
{
    public string Id { get; set; }
    public string AccessCardNumber { get; set; }
    public DateOnly InSystemDate { get; set; }
    public DateOnly DateProvidedToEmployee { get; set; }
    public DateOnly ReportMissingDate { get; set; }
    public DateOnly CardReturnDate { get; set; } 
    public bool IsExpensePaid { get; set; }      
    public bool IsReportedMissing { get; set; } 
    public bool IsCardAssigned { get; set; }
    
}