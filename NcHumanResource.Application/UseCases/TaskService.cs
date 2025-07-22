using NcHumanResource.Application.DTOs;
using NcHumanResource.Domain.Entities;
using NcHumanResource.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcHumanResource.Application.UseCases
{
    public class TaskService
    {
        private readonly ITaskRepository _repo;

        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task AddTaskAsync(string employeeId, TaskItemDto dto)
        {
            var task = new TaskItem
            {
                TaskId = dto.TaskId,
                Title = dto.Title,
                Description = dto.Description,
                AssignedDate = dto.AssignedDate,
                DueDate = dto.DueDate,
                IsCompleted = dto.IsCompleted
            };

            await _repo.AddTaskAsync(employeeId, task);
        }

        public async Task<IEnumerable<TaskItem>> GetTasksAsync(string employeeId)
            => await _repo.GetTasksAsync(employeeId);

        public async Task UpdateTaskAsync(string employeeId, TaskItemDto dto)
        {
            var task = new TaskItem
            {
                TaskId = dto.TaskId,
                Title = dto.Title,
                Description = dto.Description,
                AssignedDate = dto.AssignedDate,
                DueDate = dto.DueDate,
                IsCompleted = dto.IsCompleted
            };

            await _repo.UpdateTaskAsync(employeeId, task);
        }

        public async Task DeleteTaskAsync(string employeeId, string taskId)
            => await _repo.DeleteTaskAsync(employeeId, taskId);
    }
}
