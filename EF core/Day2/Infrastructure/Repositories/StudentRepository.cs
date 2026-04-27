using Domain.Interfacese;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Domain.Entities.Student>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                        .ThenInclude(c => c.Instructor)
                .ToListAsync();
        }

        public async Task<Domain.Entities.Student> GetStudentById(int id)
        {
            {
                return await _context.Students
                    .Include(s => s.StudentCourses)
                        .ThenInclude(sc => sc.Course)
                            .ThenInclude(c => c.Instructor)
                    .FirstOrDefaultAsync(s => s.Id == id);
            }

        }

        public async Task<List<Student>> GetStudentsLazy()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student> GetStudentExplicit(int id)
        {
            var student = await _context.Students.FindAsync(id);

            await _context.Entry(student)
                .Collection(s => s.StudentCourses)
                .LoadAsync();

            foreach (var sc in student.StudentCourses)
            {
                await _context.Entry(sc)
                    .Reference(x => x.Course)
                    .LoadAsync();
            }

            return student;
        }
    }
}
