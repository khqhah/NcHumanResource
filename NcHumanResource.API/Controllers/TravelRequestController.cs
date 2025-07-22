using Microsoft.AspNetCore.Mvc;
using NcHumanResource.Application.DTOs;
using NcHumanResource.Application.UseCases;

namespace NcHumanResource.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelRequestController : ControllerBase
    {
        private readonly TravelRequestService _service;

        public TravelRequestController(TravelRequestService service)
        {
            _service = service;
        }

        [HttpPost("{employeeId}")]
        public async Task<IActionResult> Add(string employeeId, [FromBody] TravelRequestDto dto)
        {
            await _service.AddAsync(employeeId, dto);
            return Ok("Travel request submitted.");
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> Get(string employeeId)
        {
            var result = await _service.GetAllAsync(employeeId);
            return Ok(result);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> Update(string employeeId, [FromBody] TravelRequestDto dto)
        {
            await _service.UpdateAsync(employeeId, dto);
            return Ok("Travel request updated.");
        }

        [HttpDelete("{employeeId}/{requestId}")]
        public async Task<IActionResult> Delete(string employeeId, string requestId)
        {
            await _service.DeleteAsync(employeeId, requestId);
            return Ok("Travel request deleted.");
        }
    }
}