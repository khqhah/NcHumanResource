using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class Certification
    {
        public string CertificationId { get; set; }
        public string Name { get; set; }
        public string IssuingAuthority { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpiryDate { get; set; }
    }

}
