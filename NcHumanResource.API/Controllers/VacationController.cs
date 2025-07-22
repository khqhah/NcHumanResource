using Microsoft.AspNetCore.Mvc;
using NcHumanResource.Application.DTOs;
using NcHumanResource.Application.UseCases;

namespace NcHumanResource.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacationController : ControllerBase
    {
        private readonly VacationService _service;

        public VacationController(VacationService service)
        {
            _service = service;
        }

        [HttpPost("{employeeId}")]
        public async Task<IActionResult> Add(string employeeId, [FromBody] VacationRequestDto dto)
        {
            await _service.AddAsync(employeeId, dto);
            return Ok("Vacation request submitted.");
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> Get(string employeeId)
        {
            var result = await _service.GetAllAsync(employeeId);
            return Ok(result);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> Update(string employeeId, [FromBody] VacationRequestDto dto)
        {
            await _service.UpdateAsync(employeeId, dto);
            return Ok("Vacation updated.");
        }

        [HttpDelete("{employeeId}/{vacationRequestId}")]
        public async Task<IActionResult> Delete(string employeeId, string vacationRequestId)
        {
            await _service.DeleteAsync(employeeId, vacationRequestId);
            return Ok("Vacation request deleted.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetVacationRegisterAsync();
            return Ok(result);
        }

    }

}
