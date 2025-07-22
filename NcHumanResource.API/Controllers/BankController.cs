using Microsoft.AspNetCore.Mvc;
using NcHumanResource.Application.DTOs;
using NcHumanResource.Application.UseCases;

namespace NcHumanResource.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankController : ControllerBase
    {
        private readonly BankService _service;

        public BankController(BankService service)
        {
            _service = service;
        }

        [HttpPost("{employeeId}")]
        public async Task<IActionResult> Add(string employeeId, [FromBody] BankDto dto)
        {
            await _service.AddBankAsync(employeeId, dto);
            return Ok("Bank record added.");
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> Get(string employeeId)
        {
            var data = await _service.GetBanksAsync(employeeId);
            return Ok(data);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> Update(string employeeId, [FromBody] BankDto dto)
        {
            await _service.UpdateBankAsync(employeeId, dto);
            return Ok("Bank record updated.");
        }

        [HttpDelete("{employeeId}/{bankId}")]
        public async Task<IActionResult> Delete(string employeeId, string bankId)
        {
            await _service.DeleteBankAsync(employeeId, bankId);
            return Ok("Bank record deleted.");
        }
    }

}
