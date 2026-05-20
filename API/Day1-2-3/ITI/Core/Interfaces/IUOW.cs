using Core.Models;
using Core.Interfaces;

namespace Core.Interfaces
{
    public interface IUOW
    {
        IGenericRepo<Course> CourseRepository { get; }
        IStudentRepository StudentRepository { get; }
        IGenericRepo<Department> DepartmentRepository { get; }

        Task<int> CompleteAsync();
    }
}