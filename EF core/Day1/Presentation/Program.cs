using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Entities;

class Program
{
    static async Task Main()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=.;Database=Company_SD;Trusted_Connection=True;Encrypt=False;")
            .Options;

        var context = new AppDbContext(options);

        IEmployeeRepository empRepo = new EmployeeRepository(context);
        IUnitOfWork uow = new UnitOfWork(context, empRepo);

        while (true)
        {
            Console.WriteLine("\n===== EMPLOYEE MENU =====");
            Console.WriteLine("1- Add Employee");
            Console.WriteLine("2- Get All Employees");
            Console.WriteLine("3- Get By SSN");
            Console.WriteLine("4- Update Employee");
            Console.WriteLine("5- Delete Employee");
            Console.WriteLine("0- Exit");

            Console.Write("Choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await AddEmployee(uow);
                    break;

                case "2":
                    await GetAll(uow);
                    break;

                case "3":
                    await GetById(uow);
                    break;

                case "4":
                    await UpdateEmployee(uow);
                    break;

                case "5":
                    await DeleteEmployee(uow);
                    break;

                case "0":
                    return;
            }
        }
    }

    static async Task AddEmployee(IUnitOfWork uow)
    {
        Console.Write("SSN: ");
        int ssn = int.Parse(Console.ReadLine());

        Console.Write("First Name: ");
        string fname = Console.ReadLine();

        Console.Write("Last Name: ");
        string lname = Console.ReadLine();

        Console.Write("Salary: ");
        int salary = int.Parse(Console.ReadLine());

        var emp = new Employee
        {
            Ssn = ssn,
            Fname = fname,
            Lname = lname,
            Salary = salary
        };

        await uow.Employees.AddAsync(emp);
        await uow.CompleteAsync();

        Console.WriteLine("Employee Added ✔");
    }

    static async Task GetAll(IUnitOfWork uow)
    {
        var list = await uow.Employees.GetAllAsync();

        Console.WriteLine("\n--- Employees ---");
        foreach (var e in list)
        {
            Console.WriteLine($"{e.Ssn} | {e.Fname} {e.Lname} | {e.Salary}");
        }
    }

    static async Task GetById(IUnitOfWork uow)
    {
        Console.Write("Enter SSN: ");
        int ssn = int.Parse(Console.ReadLine());

        var emp = await uow.Employees.GetBySsnAsync(ssn);

        if (emp == null)
        {
            Console.WriteLine("Not Found ❌");
            return;
        }

        Console.WriteLine($"{emp.Ssn} | {emp.Fname} {emp.Lname} | {emp.Salary}");
    }

    static async Task UpdateEmployee(IUnitOfWork uow)
    {
        Console.Write("Enter SSN: ");
        int ssn = int.Parse(Console.ReadLine());

        var emp = await uow.Employees.GetBySsnAsync(ssn);

        if (emp == null)
        {
            Console.WriteLine("Not Found ❌");
            return;
        }

        Console.Write("New First Name: ");
        emp.Fname = Console.ReadLine();

        Console.Write("New Last Name: ");
        emp.Lname = Console.ReadLine();

        Console.Write("New Salary: ");
        emp.Salary = int.Parse(Console.ReadLine());

        uow.Employees.Update(emp);
        await uow.CompleteAsync();

        Console.WriteLine("Updated ✔");
    }

    static async Task DeleteEmployee(IUnitOfWork uow)
    {
        Console.Write("Enter SSN: ");
        int ssn = int.Parse(Console.ReadLine());

        var emp = await uow.Employees.GetBySsnAsync(ssn);

        if (emp == null)
        {
            Console.WriteLine("Not Found ❌");
            return;
        }

        uow.Employees.Delete(emp);
        await uow.CompleteAsync();

        Console.WriteLine("Deleted ✔");
    }
}