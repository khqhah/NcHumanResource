using Microsoft.AspNetCore.Mvc;
using NcHumanResource.Application.DTOs;
using NcHumanResource.Application.UseCases;

namespace NcHumanResource.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TalentController : ControllerBase
    {
        private readonly TalentService _service;

        public TalentController(TalentService service)
        {
            _service = service;
        }

        [HttpPost("{employeeId}")]
        public async Task<IActionResult> Add(string employeeId, [FromBody] TalentDto dto)
        {
            try
            {
                await _service.AddTalentAsync(employeeId, dto);
                return Ok("Talent added.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> Get(string employeeId)
        {
            try
            {
                var result = await _service.GetTalentsAsync(employeeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> Update(string employeeId, [FromBody] TalentDto dto)
        {
            try
            {
                await _service.UpdateTalentAsync(employeeId, dto);
                return Ok("Talent updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{employeeId}/{talentId}")]
        public async Task<IActionResult> Delete(string employeeId, string talentId)
        {
            try
            {
                await _service.DeleteTalentAsync(employeeId, talentId);
                return Ok("Talent deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
