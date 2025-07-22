using Microsoft.AspNetCore.Mvc;
using NcHumanResource.Application.DTOs;
using NcHumanResource.Application.UseCases;

namespace NcHumanResource.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseRequestController : ControllerBase
    {
        private readonly ExpenseRequestService _service;

        public ExpenseRequestController(ExpenseRequestService service)
        {
            _service = service;
        }

        [HttpPost("{employeeId}")]
        public async Task<IActionResult> Add(string employeeId, [FromBody] ExpenseRequestDto dto)
        {
            await _service.AddAsync(employeeId, dto);
            return Ok("Expense request submitted.");
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> Get(string employeeId)
        {
            var result = await _service.GetAllAsync(employeeId);
            return Ok(result);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> Update(string employeeId, [FromBody] ExpenseRequestDto dto)
        {
            await _service.UpdateAsync(employeeId, dto);
            return Ok("Expense request updated.");
        }

        [HttpDelete("{employeeId}/{requestId}")]
        public async Task<IActionResult> Delete(string employeeId, string requestId)
        {
            await _service.DeleteAsync(employeeId, requestId);
            return Ok("Expense request deleted.");
        }
    }
}