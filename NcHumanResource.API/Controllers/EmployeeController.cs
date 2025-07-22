using Microsoft.AspNetCore.Mvc;
using NcHumanResource.Application.DTOs;
using NcHumanResource.Application.UseCases;

namespace NcHumanResource.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _service;
        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EmployeeDto dto)
        {

            var department = await _service.GetByIdAsync(dto.NcEmployeeID);
            if (department != null)
            {
                return Ok("Please Change Id Record Already Exists for this ID");
            }
            else
            {
                await _service.AddAsync(dto);
                return Ok("Employee added");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var emp = await _service.GetAllAsync();
            return Ok(emp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return Ok("Employee deleted");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var emp = await _service.GetByIdAsync(id);

            if (emp == null)
                return NotFound("Employee not found");

            return Ok(emp);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] EmployeeDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok("Employee updated");
        }
        [HttpPatch("{id}/department")]
        public async Task<IActionResult> UpdateDepartment(string id, [FromBody] string departmentId)
        {
            if (string.IsNullOrEmpty(departmentId))
                return BadRequest("Department ID cannot be null or empty.");

            try
            {
                await _service.UpdateDepartmentAsync(id, departmentId);
                return NoContent(); // 204 Success
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); // Or handle/log appropriately
            }
        }

    }
}
