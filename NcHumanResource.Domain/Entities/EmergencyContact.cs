using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class EmergencyContact
    {
        public string ContactId { get; set; } //= Guid.NewGuid().ToString(); // Unique identifier
        public string Name { get; set; }
        public string Relationship { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
