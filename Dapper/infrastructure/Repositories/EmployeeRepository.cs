using Dapper;
using System.Data;
using Domain.Entities;
using BusinessLogicLayer.Interfaces;
using Infrastructure.Data;


namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }

        // 🔹 Single Row
        public async Task<Employee> GetById(int id)
        {
            using var db = _context.CreateConnection();

            return await db.QueryFirstOrDefaultAsync<Employee>(
                "select * from Employee where employee_id = @Id",
                new { Id = id });
        }

        // 🔹 Scalar
        public async Task<int> GetCount()
        {
            using var db = _context.CreateConnection();

            return await db.ExecuteScalarAsync<int>(
                "select count(*) from Employee");
        }

        public async Task<decimal> GetMaxSalary()
        {
            using var db = _context.CreateConnection();

            return await db.ExecuteScalarAsync<decimal>(
                "select max(salary) from Employee");
        }

        public async Task<decimal> GetAvgSalary()
        {
            using var db = _context.CreateConnection();

            return await db.ExecuteScalarAsync<decimal>(
                "select avg(salary) from Employee");
        }

        // 🔹 Insert
        public async Task<int> Insert(Employee emp)
        {
            using var db = _context.CreateConnection();

            return await db.ExecuteAsync(
                @"insert into Employee(first_name,last_name,department_id,hire_date,salary)
              values (@First,@Last,@Dept,@Date,@Salary)",
                new
                {
                    First = emp.First_Name,
                    Last = emp.Last_Name,
                    Dept = emp.Department_Id,
                    Date = emp.Hire_Date,
                    Salary = emp.Salary
                });
        }

        // 🔹 Update
        public async Task<int> UpdateSalary(int id, decimal salary)
        {
            using var db = _context.CreateConnection();

            return await db.ExecuteAsync(
                "update Employee set salary = @Salary where employee_id = @Id",
                new { Salary = salary, Id = id });
        }

        // 🔹 Delete
        public async Task<int> Delete(int id)
        {
            using var db = _context.CreateConnection();

            return await db.ExecuteAsync(
                "delete from Employee where employee_id = @Id",
                new { Id = id });
        }

        // 🔥 Multi Mapping
        public async Task<IEnumerable<dynamic>> GetEmployeesWithDepartments()
        {
            using var db = _context.CreateConnection();

            return await db.QueryAsync<Employee, Department, dynamic>(
                @"select e.*, d.department_id, d.department_name
              from Employee e
              join Department d on e.department_id = d.department_id",
                (e, d) => new
                {
                    EmployeeName = e.First_Name + " " + e.Last_Name,
                    Department = d.Department_Name
                },
                splitOn: "department_id");
        }

        // 🔹 Stored Procedure
        public async Task<IEnumerable<Employee>> GetAll()
        {
            using var db = _context.CreateConnection();

            return await db.QueryAsync<Employee>(
            "GetAllEmployees",
            commandType: CommandType.StoredProcedure);          
        }
    }
}