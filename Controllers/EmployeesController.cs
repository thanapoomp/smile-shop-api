using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using smileshop_api.DTOs.EmployeeDTO;
using smileshop_api.Services;

namespace smileshop_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService service;
        public EmployeesController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromForm]EmployeeDTO_ToAdd input)
        {
            return Ok(await service.AddEmployee(input));
        }
    }
}