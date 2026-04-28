namespace Domain.Entities;

public class Department
{
    public int Department_Id { get; set; }

    public string Department_Name { get; set; }

    // Optional navigation property
    public List<Employee> Employees { get; set; }
}