using Domain.Entities;
namespace BusinessLogicLayer.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department> GetById(int id);
        Task<IEnumerable<Department>> GetAll();
        Task<int> Insert(Department dept);
    }
}

