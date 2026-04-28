using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // 🔹 Get All
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await employeeService.GetAll();
            return Ok(result);
        }

        // 🔹 Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await employeeService.GetById(id);

            if (result == null)
                return NotFound("Employee not found");

            return Ok(result);
        }

        // 🔹 Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid data");

            await employeeService.Create(dto);

            return Ok("Employee created successfully");
        }

        // 🔹 Update Salary
        [HttpPut("salary")]
        public async Task<IActionResult> UpdateSalary([FromBody] UpdateEmployeeSalaryDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid data");

            await employeeService.UpdateSalary(dto);

            return Ok("Salary updated successfully");
        }

        // 🔹 Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await employeeService.Delete(id);
            return Ok("Deleted successfully");
        }

        // 🔹 Stats

        [HttpGet("count")]
        public async Task<IActionResult> GetCount()
        {
            var count = await employeeService.GetEmployeeCount();
            return Ok(count);
        }

        [HttpGet("max-salary")]
        public async Task<IActionResult> GetMaxSalary()
        {
            var max = await employeeService.GetMaxSalary();
            return Ok(max);
        }

        [HttpGet("avg-salary")]
        public async Task<IActionResult> GetAvgSalary()
        {
            var avg = await employeeService.GetAvgSalary();
            return Ok(avg);
        }

        // 🔹 Join (Employee + Department)
        [HttpGet("with-departments")]
        public async Task<IActionResult> GetEmployeesWithDepartments()
        {
            var result = await employeeService.GetEmployeesWithDepartments();
            return Ok(result);
        }
    }
}