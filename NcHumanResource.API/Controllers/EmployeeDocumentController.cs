using Microsoft.AspNetCore.Mvc;
using NcHumanResource.Application.DTOs;
using NcHumanResource.Application.UseCases;

namespace NcHumanResource.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeDocumentController : ControllerBase
    {
        private readonly EmployeeDocumentService _service;

        public EmployeeDocumentController(EmployeeDocumentService service)
        {
            _service = service;
        }

        [HttpPost("{employeeId}")]
        public async Task<IActionResult> Add(string employeeId, [FromBody] EmployeeDocumentDto dto)
        {
            await _service.AddDocumentAsync(employeeId, dto);
            return Ok("Document added.");
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> Get(string employeeId)
        {
            var data = await _service.GetDocumentsAsync(employeeId);
            return Ok(data);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> Update(string employeeId, [FromBody] EmployeeDocumentDto dto)
        {
            await _service.UpdateDocumentAsync(employeeId, dto);
            return Ok("Document updated.");
        }

        [HttpDelete("{employeeId}/{documentId}")]
        public async Task<IActionResult> Delete(string employeeId, string documentId)
        {
            await _service.DeleteDocumentAsync(employeeId, documentId);
            return Ok("Document deleted.");
        }
    }

}
