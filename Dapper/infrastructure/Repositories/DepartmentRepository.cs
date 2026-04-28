using BusinessLogicLayer.Interfaces;
using Dapper;
using Domain.Entities;
using System.Data;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DapperContext _context;

        public DepartmentRepository(DapperContext context)
        {
            _context = context;
        }

        // 🔹 Get By Id
        public async Task<Department?> GetById(int id)
        {
            using var db = _context.CreateConnection();

            return await db.QueryFirstOrDefaultAsync<Department>(
                "select * from Department where department_id = @Id",
                new { Id = id });
        }

        // 🔹 Get All
        public async Task<IEnumerable<Department>> GetAll()
        {
            using var db = _context.CreateConnection();

            return await db.QueryAsync<Department>(
                "select * from Department");
        }

        // 🔹 Insert
        public async Task<int> Insert(Department dept)
        {
            using var db = _context.CreateConnection();

            return await db.ExecuteAsync(
                "insert into Department(department_name) values (@Name)",
                new { Name = dept.Department_Name });
        }
    }
}