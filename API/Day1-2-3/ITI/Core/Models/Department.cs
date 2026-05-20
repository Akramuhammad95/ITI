namespace Core.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SupervisorId { get; set; }

        public Supervisor Supervisor { get; set; }

        public ICollection<Student> Students { get; set; }
            = new HashSet<Student>();
    }
}