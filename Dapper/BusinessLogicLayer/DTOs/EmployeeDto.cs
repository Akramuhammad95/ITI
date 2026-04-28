namespace BusinessLogicLayer.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
    }
}
