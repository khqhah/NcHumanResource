using Microsoft.AspNetCore.Mvc;
using NcHumanResource.Application.DTOs;
using NcHumanResource.Application.UseCases;
using NcHumanResource.Domain.Entities;

namespace NcHumanResource.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentService _service;

        public DepartmentsController(DepartmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DepartmentDto dto)
        {

            var department = await _service.GetByIdAsync(dto.DepartmentID);
            if (department != null)
            {
                return Ok("Please Change Id Record Already Exists for this ID");                
            }
            else
            {
                await _service.AddAsync(dto);
                return Ok("Department added");
            }            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _service.GetAllAsync();
            return Ok(departments);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return Ok("Department deleted");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var department = await _service.GetByIdAsync(id);

            if (department == null)
                return NotFound("Department not found");

            return Ok(department);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] DepartmentDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok("Department updated");
        }
    }
}