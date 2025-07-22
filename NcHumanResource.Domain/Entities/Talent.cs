using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class Talent
    {
        public string TalentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProficiencyLevel { get; set; } // e.g. 1-5
    }

}
