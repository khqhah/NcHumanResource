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
    public class TodoListService
    {
        private readonly ITodoListRepository _repo;

        public TodoListService(ITodoListRepository repo)
        {
            _repo = repo;
        }

        public async Task AddTaskAsync(string employeeId, TodoItemDto dto)
        {
            var task = new TodoItem
            {
                TaskId = dto.TaskId,
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = dto.IsCompleted,
                CreatedAt = dto.CreatedAt,
                DueDate = dto.DueDate
            };
            await _repo.AddTaskAsync(employeeId, task);
        }

        public async Task<IEnumerable<TodoItem>> GetTasksAsync(string employeeId)
            => await _repo.GetTasksAsync(employeeId);

        public async Task UpdateTaskAsync(string employeeId, TodoItemDto dto)
        {
            var task = new TodoItem
            {
                TaskId = dto.TaskId,
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = dto.IsCompleted,
                CreatedAt = dto.CreatedAt,
                DueDate = dto.DueDate
            };
            await _repo.UpdateTaskAsync(employeeId, task);
        }

        public async Task DeleteTaskAsync(string employeeId, string taskId)
            => await _repo.DeleteTaskAsync(employeeId, taskId);
    }

}
