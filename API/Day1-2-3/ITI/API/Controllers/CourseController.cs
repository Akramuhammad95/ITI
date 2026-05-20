using Core.DTOs;
using Core.Interfaces;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        // get()
        [HttpGet("get")]
        public async Task<IActionResult> get()
        {
            var courses = await _courseService.GetAllCoursesAsync();

            if (courses == null || !courses.Any())
                return NotFound();

            return Ok(courses);
        }

        // getById(id)
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> getById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        // couseByName(name)
        [HttpGet("couseByName/{name}")]
        public async Task<IActionResult> couseByName(string name)
        {
            var course = await _courseService.GetCourseByNameAsync(name);

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        // post(course)
        [HttpPost("post")]
        public async Task<IActionResult> post([FromBody] CourseCreateDto course)
        {
            if (course == null)
                return BadRequest();

            

            var createdCourse = await _courseService.CreateCourseAsync(course);

            return StatusCode(201, createdCourse);
        }

        // put(id, course)
        [HttpPut("put/{id}")]
        public async Task<IActionResult> put(int id, [FromBody] CourseDto course)
        {
            if (id != course.Id)
                return BadRequest();

            var existingCourse = await _courseService.GetCourseByIdAsync(id);

            if (existingCourse == null)
                return NotFound();

            await _courseService.UpdateCourseAsync(id, course);

            return NoContent();
        }

        // deleteCourse(id)
        [HttpDelete("deleteCourse/{id}")]
        public async Task<IActionResult> deleteCourse(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            if (course == null)
                return NotFound();

            await _courseService.DeleteCourseAsync(id);

            var courses = await _courseService.GetAllCoursesAsync();

            return Ok(courses);
        }
    }
}