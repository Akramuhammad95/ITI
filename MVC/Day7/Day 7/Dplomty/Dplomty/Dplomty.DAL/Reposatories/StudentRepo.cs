using Dplomty.DAL.Entities;
using Dplomty.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dplomty.DAL.Reposatories
{
    public class StudentRepo : IStudentRepo
    {
        AppDbContext _dbContext ;

        public StudentRepo (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateStudent(Student s)
        {
            _dbContext.Students.Add(s);
            _dbContext.SaveChanges();
        }

        public Student? GetStudentById(int id)
        {
          return _dbContext.Students
                .Find(id);
        }

        public List<Student> GetAllStudent()
        {
            return _dbContext.Students
                //.AsNoTracking()
                .ToList();
        }

        public void UpdateStudent(Student s)
        {
            _dbContext.Students.Update(s);

            _dbContext.SaveChanges ();
        }

        public void DeleteStudent(int id)
        {
            var student =  _dbContext.Students
                .Find(id);
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
        }
        }
    }
