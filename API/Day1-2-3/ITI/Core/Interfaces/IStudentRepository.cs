using Core.Models;

namespace Core.Interfaces
{
    public interface IStudentRepository : IGenericRepo<Student>
    {
        Task<IEnumerable<Student>> GetAllWithDepartmentAsync();
        Task<Student> GetByIdWithDepartmentAsync(int id);
    }
}