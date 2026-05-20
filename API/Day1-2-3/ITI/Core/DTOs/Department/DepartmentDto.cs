namespace Core.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string SupervisorName { get; set; }
        public int StudentsCount { get; set; }
    }
}