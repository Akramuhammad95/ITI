using Core.Entities;

namespace Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int ssn);
        Task<Employee?> GetBySsnAsync(int ssn);
        Task AddAsync(Employee emp);
        void Update(Employee emp);
        void Delete(Employee emp);
    }
}