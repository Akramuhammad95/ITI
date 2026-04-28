namespace Domain.Entities;

public class Employee
{
    public int Employee_Id { get; set; }

    public string First_Name { get; set; }

    public string Last_Name { get; set; }

    public DateTime Hire_Date { get; set; }

    public decimal Salary { get; set; }

    // 🔥 Foreign Key
    public int Department_Id { get; set; }

    // Optional navigation (not required for Dapper, but useful)
    public Department Department { get; set; }
}