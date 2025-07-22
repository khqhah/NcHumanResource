using Microsoft.AspNetCore.Mvc;
using NcHumanResource.Application.DTOs;
using NcHumanResource.Application.UseCases;
using NcHumanResource.Domain.Entities;

namespace NcHumanResource.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmergencyContactController : ControllerBase
    {
        private readonly EmergencyContactService _service;

        public EmergencyContactController(EmergencyContactService service)
        {
            _service = service;
        }

        /// <summary>
        /// Add a new emergency contact to an employee
        /// </summary>
        [HttpPost("{employeeId}")]
        public async Task<IActionResult> AddEmergencyContact(string employeeId, [FromBody] EmergencyContactDto contactDto)
        {
            await _service.AddEmergencyContactAsync(employeeId, contactDto);
            return Ok("Emergency contact added successfully.");
        }

        /// <summary>
        /// Get all emergency contacts for an employee
        /// </summary>
        [HttpGet("{employeeId}")]
        public async Task<ActionResult<IEnumerable<EmergencyContact>>> GetEmergencyContacts(string employeeId)
        {
            var contacts = await _service.GetEmergencyContactsAsync(employeeId);
            return Ok(contacts);
        }

        /// <summary>
        /// Update an existing emergency contact
        /// </summary>
        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmergencyContact(string employeeId, [FromBody] EmergencyContactDto updatedDto)
        {
            await _service.UpdateEmergencyContactAsync(employeeId, updatedDto);
            return Ok("Emergency contact updated successfully.");
        }

        /// <summary>
        /// Delete an emergency contact for an employee
        /// </summary>
        [HttpDelete("{employeeId}/{contactId}")]
        public async Task<IActionResult> DeleteEmergencyContact(string employeeId, string contactId)
        {
            await _service.DeleteEmergencyContactAsync(employeeId, contactId);
            return Ok("Emergency contact deleted successfully.");
        }
    }
}