using Domain.Entities;
namespace BusinessLogicLayer.Interfaces
{
    public interface IEmployeeRepository
    {
        // 🔹 Single
        Task<Employee> GetById(int id);

        // 🔹 Scalar
        Task<int> GetCount();
        Task<decimal> GetMaxSalary();
        Task<decimal> GetAvgSalary();

        // 🔹 CRUD
        Task<int> Insert(Employee emp);
        Task<int> UpdateSalary(int id, decimal salary);
        Task<int> Delete(int id);

        // 🔹 Join (Multi-Mapping)
        Task<IEnumerable<dynamic>> GetEmployeesWithDepartments();

        // 🔹 Stored Procedure
        Task<IEnumerable<Employee>> GetAll();
    }
}