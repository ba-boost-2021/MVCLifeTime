using BilgeAdam.Services.Abstractions;
using BilgeAdam.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet("list")]
        public IActionResult GetEmployees()
        {
            return Ok(service.GetEmployees());
        }

        [HttpPost("create")]
        public IActionResult CreateEmployee([FromBody] NewEmployeeDTO data)
        {
            return Ok(service.CreateEmployee(data));
        }
    }
}
