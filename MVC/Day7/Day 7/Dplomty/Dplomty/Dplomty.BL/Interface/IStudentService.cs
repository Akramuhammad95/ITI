using Dplomty.BL.Dtos.StudentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dplomty.BL.Interface
{
    public interface IStudentService
    {
        public GetStudentDto GetStudentById(int id);
        public void CreateStudent(CreateStudentDto student);
        public List<StudentDto> GetStudents();
        public void UpdateStudent(StudentDto studentDto);
        public void DeleteStudent(int id);


    }
}
