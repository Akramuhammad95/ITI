using Core.Interfaces;
using Core.Models;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public class UOW : IUOW
    {
        private readonly ApplicationDbContext _context;

        private IGenericRepo<Course> _courseRepository;
        private IStudentRepository _studentRepository;
        private IGenericRepo<Department> _departmentRepository;

        public UOW(ApplicationDbContext context)
        {
            _context = context;
        }

        // ================= COURSE =================
        public IGenericRepo<Course> CourseRepository
        {
            get
            {
                if (_courseRepository == null)
                    _courseRepository = new GenericRepo<Course>(_context);

                return _courseRepository;
            }
        }

        // ================= STUDENT =================
        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                    _studentRepository = new StudentRepository(_context);

                return _studentRepository;
            }
        }

        // ================= DEPARTMENT =================
        public IGenericRepo<Department> DepartmentRepository
        {
            get
            {
                if (_departmentRepository == null)
                    _departmentRepository = new GenericRepo<Department>(_context);

                return _departmentRepository;
            }
        }

        // ================= SAVE =================
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}