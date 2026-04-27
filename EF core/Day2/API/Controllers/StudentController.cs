using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost("add-student")]
        public IActionResult AddStudent([FromBody] StudentDTO student)
        {
            studentService.AddStudent(student);
            return Ok();
        }
        [HttpGet("students-explicit/{id}")]
        public async Task<IActionResult> GetStudentExplicit(int id)
        {
            var student = await studentService.GetStudentExplicit(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpGet("students-lazy")]
        public async Task<IActionResult> GetStudentsLazy()
        {
            var students = await studentService.GetStudentsLazy();
            return Ok(students);
        }
    }
}