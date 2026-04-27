using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IStudentService
    {
        public Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();
        Task<List<StudentDTO>> GetStudentsLazy();
        Task<StudentDTO> GetStudentExplicit(int id);
        public Task<StudentDTO> GetStudentById(int id);
        public void AddStudent(StudentDTO student);
    }
}
