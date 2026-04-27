using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
            => await _context.Employee.ToListAsync();

        public async Task<Employee?> GetByIdAsync(int ssn)
            => await _context.Employee.FirstOrDefaultAsync(e => e.Ssn == ssn);

        public async Task<Employee?> GetBySsnAsync(int ssn)
            => await _context.Employee.FirstOrDefaultAsync(e => e.Ssn == ssn);

        public async Task AddAsync(Employee emp)
            => await _context.Employee.AddAsync(emp);

        public void Update(Employee emp)
            => _context.Employee.Update(emp);

        public void Delete(Employee emp)
            => _context.Employee.Remove(emp);

    }
}