using BusinessLogicLayer.DTOs;
using Domain.Entities;
using BusinessLogicLayer.Interfaces;

namespace BusinessLogicLayer.Services
{

    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repo;

        public DepartmentService(IDepartmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<DepartmentDto> GetById(int id)
        {
            var dept = await _repo.GetById(id);

            if (dept == null)
                return null;

            return new DepartmentDto
            {
                DepartmentId = dept.Department_Id,
                DepartmentName = dept.Department_Name
            };
        }

        public async Task<IEnumerable<DepartmentDto>> GetAll()
        {
            var depts = await _repo.GetAll();
            return depts.Select(d => new DepartmentDto
            {
                DepartmentId = d.Department_Id,
                DepartmentName = d.Department_Name
            });
        }

        public async Task Create(CreateDepartmentDto dto)
        {
            if (string.IsNullOrEmpty(dto.DepartmentName))
                throw new KeyNotFoundException("Department name is required");

            var dept = new Department
            {
                Department_Name = dto.DepartmentName
            };

            var result = await _repo.Insert(dept);

            if (result == 0)
                throw new KeyNotFoundException("Insert failed");
        }
    }
}
