using Microsoft.AspNetCore.Mvc;
using NcHumanResource.Application.DTOs;
using NcHumanResource.Application.UseCases;

namespace NcHumanResource.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeePreferenceController : ControllerBase
    {
        private readonly EmployeePreferenceService _service;

        public EmployeePreferenceController(EmployeePreferenceService service)
        {
            _service = service;
        }

        [HttpPost("{employeeId}")]
        public async Task<IActionResult> Add(string employeeId, [FromBody] EmployeePreferenceDto dto)
        {
            await _service.AddAsync(employeeId, dto);
            return Ok("Preference added.");
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> Get(string employeeId)
        {
            var result = await _service.GetAsync(employeeId);
            return Ok(result);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> Update(string employeeId, [FromBody] EmployeePreferenceDto dto)
        {
            await _service.UpdateAsync(employeeId, dto);
            return Ok("Preference updated.");
        }

        [HttpDelete("{employeeId}/{preferenceId}")]
        public async Task<IActionResult> Delete(string employeeId, string preferenceId)
        {
            await _service.DeleteAsync(employeeId, preferenceId);
            return Ok("Preference deleted.");
        }
    }
}
