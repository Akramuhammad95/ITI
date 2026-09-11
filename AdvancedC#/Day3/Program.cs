namespace Day3
{
    public class Program
    {
        public delegate string BookDelegate(Book b);
        static void Main(string[] args)
        {
            Company company = new Company("Tech Solutions", "A software development company", 1000000m);
            Employee emp1 = new Employee("Alice", 50000m);
            Employee emp2 = new Employee("Bob", 10000m);
            Employee emp3 = new Employee("Charlie", 15000m);
            EmployeeList employeeList = new EmployeeList();
            employeeList.AddEmployee(emp1);
            employeeList.AddEmployee(emp2);
            employeeList.AddEmployee(emp3);

            

            
            company.PaySalaries(employeeList);


            Console.WriteLine("_________________________________________________");

            //company.OnSalaryPaid += Company_OnSalaryPaid;


            // Update salaries of employees earning less than 20000 by giving them a 10% raise




            company.OnSalaryPaid += Company_OnSalaryPaid;

            company.OnSalaryUpdate += Company_OnSalaryUpdate; 

            company.PaySalaries(employeeList);
            Console.WriteLine("-----update-----");

            company.UpdateSalaries(employeeList, 15, salary => salary < 200000000);


            BookFunctions bookFunctions = new BookFunctions();
            Console.WriteLine("______________________________________________");

            Book book1 = new Book("Vip","Design patterns",DateTime.Now, 10.99m);
            Book book2 = new Book("alice", "Solid", DateTime.Now, 10.99m);
            Book book3 = new Book("axis", "clean code", DateTime.Now, 10.99m);

            List<Book> books = new List<Book> { book1, book2, book3 };



            Func<Book, string> bookFunc = BookFunctions.GetTitle;





            Console.WriteLine("-----lambda------");
            LibraryEngine.ProcessBooks(books, b => b.Title);
            Console.WriteLine("------built-in delegate-----");

            LibraryEngine.ProcessBooks(books, bookFunc);

            Console.WriteLine("-----delegate------");

            BookDelegate del = BookFunctions.GetTitle;
            LibraryEngine.ProcessBooks(books, b => del(b)); 

        }

        private static void Company_OnSalaryPaid(IEmployeeList employees)
        {
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"Congratulations {emp.Name} ,You have received a salary of amount {emp.Salary}");
            }
        }

    

        private static void Company_OnSalaryUpdate(IEmployeeList employees)
        {
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"Congratulations {emp.Name} ,You have Update a salary of amount {emp.Salary}");
            }
        }
    }
}