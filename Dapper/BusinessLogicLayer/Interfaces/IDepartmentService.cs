using BusinessLogicLayer.DTOs;
namespace BusinessLogicLayer.Interfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentDto> GetById(int id);
        Task<IEnumerable<DepartmentDto>> GetAll();
        Task Create(CreateDepartmentDto dto);
    }
}

