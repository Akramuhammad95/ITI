using BusinessLogicLayer.DTOs;
namespace BusinessLogicLayer.Interfaces
{
    public interface IEmployeeService
    {
        // 🔹 Queries
        Task<EmployeeDto> GetById(int id);
        Task<IEnumerable<EmployeeDto>> GetAll();

        // 🔹 Stats
        Task<int> GetEmployeeCount();
        Task<decimal> GetMaxSalary();
        Task<decimal> GetAvgSalary();

        // 🔹 Commands
        Task Create(CreateEmployeeDto dto);
        Task UpdateSalary(UpdateEmployeeSalaryDto dto);
        Task Delete(int id);

        // 🔹 Join
        Task<IEnumerable<EmployeeWithDepartmentDto>> GetEmployeesWithDepartments();
    }

}

