using EmployeeManagement.Application.Commands;
using EmployeeManagement.Application.Queries;
using EmployeeManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Hybrid;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthentication(Realm = "EmployeeController")]
    public class EmployeeController(ISender sender,HybridCache cache) : ControllerBase
    {
        
        [HttpPost("")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeEntity employee)
        {
            var result = await sender.Send(new AddEmployeeCommand(employee));
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var result = await sender.Send(new GetAllEmployeeQuery());
            return Ok(result);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] Guid employeeId,CancellationToken cancellationToken)
        {
            var employee = await cache.GetOrCreateAsync(
                employeeId.ToString(),
                async token =>
                {
                    return await sender.Send(new GetEmployeeByIdQuery(employeeId));
                },
                tags:["GetEmployeeByIdAsync"],
                cancellationToken: cancellationToken
                
            );
            return employee is null ? NotFound() : Ok(employee);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromBody] EmployeeEntity employee)
        {
            var result = await sender.Send(new UpdateEmployeeCommand(employee));
            
            await cache.SetAsync(
                employee.ToString(),
                result
            );

            return Ok(result);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] Guid employeeId)
        {
            await cache.RemoveAsync(employeeId.ToString());
            var result = await sender.Send(new DeleteEmployeeCommand(employeeId));
            return Ok(result);
        }
    }
}
