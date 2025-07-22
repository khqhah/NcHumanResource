using NcHumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task AddTaskAsync(string employeeId, TaskItem task);
        Task<IEnumerable<TaskItem>> GetTasksAsync(string employeeId);
        Task UpdateTaskAsync(string employeeId, TaskItem updatedTask);
        Task DeleteTaskAsync(string employeeId, string taskId);
    }
}