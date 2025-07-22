using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Entities
{
    public class TaskItem
    {
        public string TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly AssignedDate { get; set; }
        public DateOnly DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}