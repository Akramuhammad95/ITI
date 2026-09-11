using Day5;
using Day5.Sorting;
EmployeesList employees = new EmployeesList();



Employee e1 = new Employee("akram", new DateTime(2020, 1, 15));


Employee e2 = new Employee("sara", new DateTime(2019, 5, 10));

Employee e3 = new Employee("mohamed", new DateTime(2021, 3, 20));

Employee e4 = new Employee("ahmed", new DateTime(2018, 7, 25));

employees.Add(e1);
employees.Add(e2);
employees.Add(e3);
employees.Add(e4);

Console.WriteLine("employees before sorting");
foreach (var emp in employees)
{
    Console.WriteLine(emp);
}
Console.WriteLine("---------------------------------------------------");



MergeSort<Employee> EmpSort = new MergeSort<Employee>(new EmployeeHireDateComparer());

EmpSort.Sort(employees.ToList, 0, EmployeesList.Count - 1);

Console.WriteLine("Employees after sorting");
foreach (var emp in employees)
{
    Console.WriteLine(emp);
}

Console.WriteLine("---------------------------------------------------");

List<int> numbers = new List<int> { 5, 2, 9, 1, 5, 6 };

Console.WriteLine("numbers before sorting");
foreach (var number in numbers)
{
    Console.Write($"{number} - ");
}
Console.WriteLine();

MergeSort<int> intMergeSort = new MergeSort<int>();
intMergeSort.Sort(numbers, 0, numbers.Count - 1);

Console.WriteLine("numbers after sorting");
foreach (var number in numbers)
{
    Console.Write($"{number} - ");
}



