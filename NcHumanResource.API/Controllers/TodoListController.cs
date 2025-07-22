using Microsoft.AspNetCore.Mvc;
using NcHumanResource.Application.DTOs;
using NcHumanResource.Application.UseCases;

namespace NcHumanResource.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly TodoListService _service;

        public TodoListController(TodoListService service)
        {
            _service = service;
        }

        [HttpPost("{employeeId}")]
        public async Task<IActionResult> Add(string employeeId, [FromBody] TodoItemDto dto)
        {
            await _service.AddTaskAsync(employeeId, dto);
            return Ok("Task added.");
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> Get(string employeeId)
        {
            var tasks = await _service.GetTasksAsync(employeeId);
            return Ok(tasks);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> Update(string employeeId, [FromBody] TodoItemDto dto)
        {
            await _service.UpdateTaskAsync(employeeId, dto);
            return Ok("Task updated.");
        }

        [HttpDelete("{employeeId}/{taskId}")]
        public async Task<IActionResult> Delete(string employeeId, string taskId)
        {
            await _service.DeleteTaskAsync(employeeId, taskId);
            return Ok("Task deleted.");
        }
    }

}
