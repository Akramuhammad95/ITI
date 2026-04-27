using Application.DTOs;
using Application.Interfaces;
using Domain.Interfacese;
using Domain.Entities;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void AddStudent(StudentDTO student)
        {
            _studentRepository.AddStudent(new Student
            {
                StudentName = student.Name,
                StudentAge = student.Age
            });
        }
        
        public async Task<StudentDTO> GetStudentExplicit(int id)
        {
            var student = await _studentRepository.GetStudentExplicit(id);

            if (student == null)
            {
                return null;
            }

            return new StudentDTO
            {
                Id = student.Id,
                Name = student.StudentName,
                Age = student.StudentAge
            };
        }

        public async Task<List<StudentDTO>> GetStudentsLazy()
        {
            var students = await _studentRepository.GetStudentsLazy();
            return students.Select(s => new StudentDTO
            {
                Id = s.Id,
                Name = s.StudentName,
                Age = s.StudentAge
            }).ToList();
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            // Map Domain.Entities.Student to StudentDTO
            return students.Select(s => new StudentDTO
            {
                Id = s.Id,
                Name = s.StudentName,
                Age = s.StudentAge
                // Map other properties as needed
            });
        }

        public async Task<StudentDTO> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudentById(id);

            if (student == null)
            {
                return null;
            }

            return new StudentDTO
            {
                Id = student.Id,
                Name = student.StudentName,
                Age = student.StudentAge
            };
        }
    }
}
