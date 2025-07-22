using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class Department
    {
        
        //public string Id { get; set; }               
        public string DepartmentID { get; set; }        
        public string Name { get; set; }
    }
}
