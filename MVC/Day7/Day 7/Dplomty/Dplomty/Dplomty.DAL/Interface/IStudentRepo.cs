using Dplomty.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dplomty.DAL.Interface
{
    public interface IStudentRepo
    {

        public void CreateStudent(Student s);
        public Student? GetStudentById(int id);
        public List<Student> GetAllStudent();
        public void UpdateStudent(Student s);
        public void DeleteStudent(int id);
    }
}
