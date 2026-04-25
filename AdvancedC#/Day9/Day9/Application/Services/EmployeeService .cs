using Application.DTO;
using Application.interfaces;
using Application.Interfaces;
using Domain.Entities;


public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repo;

    public EmployeeService(IEmployeeRepository repo)
    {
        _repo = repo;
    }

    public void AddEmployee(EmployeeDto dto)
    {
        if (dto == null)
            throw new Exception("Employee is null");

        if (string.IsNullOrWhiteSpace(dto.FName))
            throw new Exception("First Name is required");

        if (string.IsNullOrWhiteSpace(dto.LName))
            throw new Exception("Last Name is required");

        if (dto.Salary <= 0)
            throw new Exception("Invalid Salary");

        // Mapping DTO → Entity
        var employee = new Employee(
            dto.SSN,
            dto.FName,
            dto.LName,
            dto.DNO,
            dto.BDate,
            dto.Address,
            dto.Gender,
            dto.Salary
        );

        _repo.Add(employee);
    }

  
    public async Task<List<EmployeeDto>> SearchEmployee(string name)
    {
        var employees = await _repo.Search(name);

        return employees.Select(e => new EmployeeDto
        {
            SSN = e.SSN,
            FName = e.FName,
            LName = e.LName,
            DNO = e.DNO,
            BDate = e.BDate,
            Address = e.Address,
            Gender = e.Gender,
            Salary = e.Salary
        }).ToList();
    }

    Task<List<EmployeeDto>> IEmployeeService.SearchEmployee(string name)
    {
        throw new NotImplementedException();
    }
}