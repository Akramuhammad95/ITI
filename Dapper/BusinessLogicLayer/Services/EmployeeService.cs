using BusinessLogicLayer.DTOs;
using Domain.Entities;
using BusinessLogicLayer.Interfaces;
namespace BusinessLogicLayer.Services
{

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        // 🔹 Get By Id
        public async Task<EmployeeDto> GetById(int id)
        {
            var emp = await _repo.GetById(id);

            if (emp == null)
                throw new Exception("Employee not found");

            return new EmployeeDto
            {
                Id = emp.Employee_Id,
                FullName = emp.First_Name + " " + emp.Last_Name,
                Salary = emp.Salary
            };
        }

        // 🔹 Get All (Stored Procedure)
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            var data = await _repo.GetAll();

            return data.Select(e => new EmployeeDto
            {
                Id = e.Employee_Id,
                FullName = e.First_Name + " " + e.Last_Name,
                Salary = e.Salary
            });
        }

        // 🔹 Scalar
        public async Task<int> GetEmployeeCount() => await _repo.GetCount();

        public async Task<decimal> GetMaxSalary() => await _repo.GetMaxSalary();

        public async Task<decimal> GetAvgSalary() => await _repo.GetAvgSalary();
        // 🔹 Create
        public async Task Create(CreateEmployeeDto dto)
        {
            if (dto.Salary <= 0)
                throw new Exception("Invalid salary");

            var emp = new Employee
            {
                First_Name = dto.FirstName,
                Last_Name = dto.LastName,
                Department_Id = dto.DepartmentId,
                Hire_Date = DateTime.Now,
                Salary = dto.Salary
            };

            var result = await _repo.Insert(emp);

            if (result == 0)
                throw new KeyNotFoundException("Insert failed");
        }

        // 🔹 Update Salary
        public async Task UpdateSalary(UpdateEmployeeSalaryDto dto)
        {
            if (dto.Salary <= 0)
                throw new KeyNotFoundException("Invalid salary");

            var result = await _repo.UpdateSalary(dto.EmployeeId, dto.Salary);

            if (result == 0)
                throw new KeyNotFoundException("Update failed or employee not found");
        }

        // 🔹 Delete
        public async Task Delete(int id)
        {
            var result = await _repo.Delete(id);

            if (result == 0)
                throw new Exception("Delete failed or employee not found");
        }

        // 🔥 Multi Mapping
        public async Task<IEnumerable<EmployeeWithDepartmentDto>> GetEmployeesWithDepartments()
        {
            var data = await _repo.GetEmployeesWithDepartments();

            return data.Select(x => new EmployeeWithDepartmentDto
            {
                EmployeeName = x.EmployeeName,
                DepartmentName = x.Department
            });
        }
    }
}