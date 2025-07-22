using Microsoft.AspNetCore.Mvc;
using NcHumanResource.Application.DTOs;
using NcHumanResource.Application.UseCases;

namespace NcHumanResource.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificationController : ControllerBase
    {
        private readonly CertificationService _service;

        public CertificationController(CertificationService service)
        {
            _service = service;
        }

        [HttpPost("{employeeId}")]
        public async Task<IActionResult> Add(string employeeId, [FromBody] CertificationDto dto)
        {
            await _service.AddCertificationAsync(employeeId, dto);
            return Ok("Certification added.");
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> Get(string employeeId)
        {
            var result = await _service.GetCertificationsAsync(employeeId);
            return Ok(result);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> Update(string employeeId, [FromBody] CertificationDto dto)
        {
            await _service.UpdateCertificationAsync(employeeId, dto);
            return Ok("Certification updated.");
        }

        [HttpDelete("{employeeId}/{certificationId}")]
        public async Task<IActionResult> Delete(string employeeId, string certificationId)
        {
            await _service.DeleteCertificationAsync(employeeId, certificationId);
            return Ok("Certification deleted.");
        }
    }
}