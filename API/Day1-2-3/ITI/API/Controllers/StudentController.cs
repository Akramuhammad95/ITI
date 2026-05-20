using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers

{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("get")]

        public async Task<IActionResult> get()
        {
            var students = await _studentService.GetAllAsync();
            if (students == null || !students.Any())
                return NotFound();
            //Apply pagination here if needed
            var numberOfStudents = students.Count();
            var pageSize = 10; // Example page size
            var totalPages = (int)Math.Ceiling((double)numberOfStudents / pageSize);
            var paginatedStudents = students.Take(pageSize); // Example of taking the first page
            return Ok(paginatedStudents);
        }
        //searching by name     
        [HttpGet("searchByName/{name}")]
        public async Task<IActionResult> searchByName(string name)
        {
            var students = await _studentService.SearchByName(name);
            if (!students.Any())
                return NotFound();
            var numberOfStudents = students.Count();    
            var pageSize = 10; // Example page size
            var totalPages = (int)Math.Ceiling((double)numberOfStudents / pageSize);
            var paginatedStudents = students.Take(pageSize); // Example of taking the first page
            return Ok(paginatedStudents);
        }

        //Creare student
        [HttpPost("Create")]
        public async Task<IActionResult> Create(StudentCreateDto student)
        {
            if (student == null) return BadRequest();
            var CreatedStudents = await _studentService.CreateAsync(student);
            return StatusCode(201, CreatedStudents);

        }
    }
}
