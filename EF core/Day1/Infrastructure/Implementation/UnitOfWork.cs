using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IEmployeeRepository Employees { get; }

        public UnitOfWork(AppDbContext context, IEmployeeRepository employeeRepository)
        {
            _context = context;
            Employees = employeeRepository;
        }

        public async Task<int> CompleteAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}