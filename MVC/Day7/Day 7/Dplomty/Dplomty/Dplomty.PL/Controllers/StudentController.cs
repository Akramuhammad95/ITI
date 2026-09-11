using Dplomty.BL.Dtos.StudentDtos;
using Dplomty.BL.Interface;
using Dplomty.PL.ViewModel.Student;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dplomty.PL.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        #region GetById
        public IActionResult GetId(int id)
        {
            var res =_studentService.GetStudentById(id);

            return View(new GetStudentVM
            {
                Name = res.Name,
                Age = res.Age,
            });
        }
        #endregion

        #region Create 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateStudentVM studentVM)
        {

            _studentService.CreateStudent(new CreateStudentDto {
            Name = studentVM.Name,
            Age = studentVM.Age
            });

            return RedirectToAction("Index","Home");
        }
        #endregion

        #region GetAll 
        public IActionResult GetAll()
        {
            var studentsDto = _studentService.GetStudents();
            var studetsVM = studentsDto.Select(x => new StudentVM { Id =x.Id,Name = x.Name, Age = x.Age }).ToList();
            return View (studetsVM);
        }
        #endregion

        #region Update 

        [HttpGet]
        public IActionResult Update(int id)
        {
            var studentDto = _studentService.GetStudentById(id);
            
            return View(new StudentVM { Id = id , Name= studentDto.Name ,Age = studentDto.Age });
        }

        [HttpPost]
        public IActionResult Update (StudentVM studentVM)
        {
            _studentService.UpdateStudent(new StudentDto { Id = studentVM.Id , Name = studentVM.Name , Age = studentVM.Age});
            return RedirectToAction("GetAll");
        }

        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
          _studentService.DeleteStudent(id);

            return RedirectToAction("GetAll");
        }
        #endregion



    }
}
