using Core.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public int? SupervisorId { get; set; }

    public Supervisor Supervisor { get; set; }

    public ICollection<Course> Courses { get; set; } = new List<Course>();
}