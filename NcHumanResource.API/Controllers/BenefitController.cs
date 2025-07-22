using Microsoft.AspNetCore.Mvc;
using NcHumanResource.Application.DTOs;
using NcHumanResource.Application.UseCases;

namespace NcHumanResource.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BenefitController : ControllerBase
    {
        private readonly BenefitService _service;

        public BenefitController(BenefitService service)
        {
            _service = service;
        }

        [HttpPost("{employeeId}")]
        public async Task<IActionResult> Add(string employeeId, [FromBody] BenefitDto dto)
        {
            try
            {
                await _service.AddBenefitAsync(employeeId, dto);
                return Ok("Benefit added.");
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
                var result = await _service.GetBenefitsAsync(employeeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> Update(string employeeId, [FromBody] BenefitDto dto)
        {
            try
            {
                await _service.UpdateBenefitAsync(employeeId, dto);
                return Ok("Benefit updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{employeeId}/{benefitId}")]
        public async Task<IActionResult> Delete(string employeeId, string benefitId)
        {
            try
            {
                await _service.DeleteBenefitAsync(employeeId, benefitId);
                return Ok("Benefit deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
