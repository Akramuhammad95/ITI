using Domain.Entities;

namespace Domain.Interfacese
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<Student>> GetAllStudentsAsync();

        public Task<List<Student>> GetStudentsLazy();
        Task<Student> GetStudentExplicit(int id);

        public Task<Student> GetStudentById(int id);
       
        //create Studetn
        public void AddStudent(Student student);


        //update Student

    }
}
