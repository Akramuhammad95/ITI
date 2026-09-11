using Dplomty.BL.Dtos.StudentDtos;
using Dplomty.BL.Interface;
using Dplomty.BL.Mapping;
using Dplomty.DAL.Entities;
using Dplomty.DAL.Interface;
using Dplomty.DAL.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dplomty.BL.Service
{
    public  class StudentService : IStudentService
    {
        public IStudentRepo _studentRepo;

        public StudentService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public GetStudentDto GetStudentById (int id)
        {

            var student =_studentRepo.GetStudentById(id);

            if (student == null)
                throw new Exception();
            else 
                return student.EntitiyToGetStudentDto();
        }

        public void CreateStudent(CreateStudentDto student)
        {

            _studentRepo.CreateStudent(new Student
            {
                Name = student.Name,
                Age = student.Age,

            });
        }

        public List<StudentDto> GetStudents()
        {
            var students = _studentRepo.GetAllStudent();

            var studentsDto = new List<StudentDto>();
           return studentsDto = students.Select(x => new StudentDto { Id = x.Id ,Name=x.Name , Age = x.Age }).ToList();
        }

        public void UpdateStudent(StudentDto studentDto)
        {
            _studentRepo.UpdateStudent(new Student
            {
                Id = studentDto.Id,
                Name = studentDto.Name,
                Age = studentDto.Age,
            });
        }

        public void DeleteStudent(int id)
        {
            var studentdto = GetStudentById(id);

            //_studentRepo.DeleteStudent(new Student { Id = id, Name = studentdto.Name, Age = studentdto.Age });
            _studentRepo.DeleteStudent(id);
        }

    }
}
