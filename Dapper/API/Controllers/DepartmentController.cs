using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        // 🔹 Get All Departments
        [HttpGet("Departments")]
        public async Task<IActionResult> GetAll()
        {
            var result = await departmentService.GetAll();
            return Ok(result);
        }

        // 🔹 Get Department By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await departmentService.GetById(id);

            if (result == null)
                return NotFound("Department not found");

            return Ok(result);
        }

        // 🔹 Create Department
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid data");

            await departmentService.Create(dto);

            return Ok("Department created successfully");
        }
    }
}