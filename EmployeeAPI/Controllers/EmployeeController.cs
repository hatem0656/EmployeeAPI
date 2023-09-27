using EmployeeAPI.Dtos;
using EmployeeAPI.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet]
        [Route("page/{page}")]
        public async Task<IActionResult> GetAllEmployees(int page)
        {
            return Ok(await _employeeService.GetAllEmployees(page));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {
            var employee = await _employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmploye([FromBody] EmployeeAddRequest employee)
        {
            var createdEmployee = await _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id }, createdEmployee);
        }

        [HttpPut]
       
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeUpdateRequest employee)
        {
            var updatedEmployee = await _employeeService.UpdateEmployee(employee);
            if (updatedEmployee == null) return NotFound();
            return Ok(updatedEmployee);
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var employee = await _employeeService.DeleteEmployee(id);
            if (employee == Guid.Empty) return NotFound();
            return NoContent();
        }

    }
}
