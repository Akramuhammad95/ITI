using System.IO;


namespace Day7
{
    internal class Program
    {
        static string filePath = "students.txt";

        static void Main(string[] args)
        {
           // MathClass.num1 = 5;
           // Thread thread1 = new(MathClass.Sum);

           // MathClass.FactorialInput = 5;
           // Thread thread2 = new(MathClass.Factorial);
           ///// Console.WriteLine(MathClass.AddResult);
           // thread1.Start();
           // thread2.Start();

            //Thread thread = new(() =>
            //{
            //    MathClass.Factorial();
            //    MathClass.Sum();


            //});
            //thread.Start();
            //thread.Join();


            // Ensure file exists
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            while (true)
            {
                Console.WriteLine("\n===== STUDENT SYSTEM =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;

                    case "2":
                        ViewStudents();
                        break;

                    case "3":
                        SearchStudent();
                        break;

                    case "4":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                File.AppendAllText(filePath, name + Environment.NewLine);
                Console.WriteLine("Student added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid name.");
            }
        }

        static void ViewStudents()
        {
            string[] students = File.ReadAllLines(filePath);

            Console.WriteLine("\n===== STUDENT LIST =====");

            if (students.Length == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine("- " + student);
            }
        }

        static void SearchStudent()
        {
            Console.Write("Enter name to search: ");
            string name = Console.ReadLine();

            string[] students = File.ReadAllLines(filePath);

            bool found = false;

            foreach (var student in students)
            {
                if (student.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    break;
                }
            }

            if (found)
                Console.WriteLine("Student FOUND ");
            else
                Console.WriteLine("Student NOT found ");
        }

    }
 }
