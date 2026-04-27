namespace Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public string StudentName { get; set; }

    public int StudentAge { get; set; }
    public virtual ICollection<StudentCourses> StudentCourses { get; set; } = new List<StudentCourses>();


}