using NcHumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Interfaces
{
    public interface ITodoListRepository
    {
        Task AddTaskAsync(string employeeId, TodoItem item);
        Task<IEnumerable<TodoItem>> GetTasksAsync(string employeeId);
        Task UpdateTaskAsync(string employeeId, TodoItem updatedItem);
        Task DeleteTaskAsync(string employeeId, string taskId);
    }
}
