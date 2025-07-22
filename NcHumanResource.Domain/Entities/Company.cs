using NcHumanResources.Domain.Entities;

namespace NcHumanResource.Domain.Entities; 
  public class Company
    {
        public string CompanyName{ get; set; }
        public ICollection<CompanyAddress> CompanyAddress { get; set; }
        public string TaxIdentifer { get; set; }
    }