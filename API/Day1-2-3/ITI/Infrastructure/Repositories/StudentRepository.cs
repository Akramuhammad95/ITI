using Core.Models;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace Infrastructure.Repositories
{
    public class StudentRepository : GenericRepo<Student> , IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllWithDepartmentAsync()
        {
            return await _context.Students
                .Include(s => s.Department)
                .ToListAsync();
        }

        public async Task<Student> GetByIdWithDepartmentAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Department)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Student>> SearchByName(string name)
        {
            return await _context.Students
                .Include(s => s.Department)
                .Include(s => s.Supervisor)
                .Where(s => s.Name.Contains(name))
                .ToListAsync();
        }

    }
}