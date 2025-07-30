using Microsoft.AspNetCore.Mvc;
using NcHumanResource.Application.DTOs;
using NcHumanResource.Application.UseCases;

namespace NcHumanResource.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnualReviewController : ControllerBase
    {
        private readonly AnnualReviewService _service;

        public AnnualReviewController(AnnualReviewService service)
        {
            _service = service;
        }

        [HttpPost("{employeeId}")]
        public async Task<IActionResult> Add(string employeeId, [FromBody] AnnualReviewDto dto)
        {
            await _service.AddAsync(employeeId, dto);
            return Ok("Review added.");
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> Get(string employeeId)
        {
            var reviews = await _service.GetAsync(employeeId);
            return Ok(reviews);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> Update(string employeeId, [FromBody] AnnualReviewDto dto)
        {
            await _service.UpdateAsync(employeeId, dto);
            return Ok("Review updated.");
        }

        [HttpDelete("{employeeId}/{reviewId}")]
        public async Task<IActionResult> Delete(string employeeId, string reviewId)
        {
            await _service.DeleteAsync(employeeId, reviewId);
            return Ok("Review deleted.");
        }
    }
}
