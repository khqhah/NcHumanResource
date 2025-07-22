using NcHumanResource.Domain;

namespace NcHumanResource.Domain.Entities; 

  public class Address
    {
        public string LineOne{ get; set; }
        public string LineTwo { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string ProvinceOrState{ get; set; }
        public string Country { get; set; }
    }
