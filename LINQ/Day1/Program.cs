using Day1;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;

List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };

var SortedNumbers = numbers.OrderBy(x => x).ToList();

SortedNumbers.PrintList();




Console.WriteLine("_______________________________________________");



//Query2: using Query1 result and show each number and it’s multiplication

var multipliedNumbers = SortedNumbers.Select(x => new { Number = x, Multiplication = x * x });
foreach (var number in multipliedNumbers)
    Console.WriteLine(number);

Console.WriteLine("_______________________________________________");
string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };

//Query1: Select names with length equal 3.
Console.WriteLine("Names with length 3:");
var NamesWithLength3 = names.Where(x => x.Length == 3).ToList();
NamesWithLength3.PrintList();
Console.WriteLine("_______________________________________________");



//Query2: Select names that contains “a” letter (Capital or Small )then sort them by length (Use toLower method and Contains method)
var NamesWithA = names.Where(x => x.ToLower().Contains("a")).OrderBy(x => x.Length).ToList();
Console.WriteLine("Names start with a");
NamesWithA.PrintList();
Console.WriteLine("_______________________________________________");

//Query3: Display the first 2 names
Console.WriteLine("Query3: Display the first 2 names\r\n");
var FirstTwoNames = names.Take(2).ToList();

FirstTwoNames.PrintList();

Console.WriteLine("_______________________________________________");


List<Student> students = new List<Student>()
{
    new Student() { 
        ID=1, FirstName="Ali",
        LastName="Mohammed",
        Subjects=new Subject[]{ new Subject(){ Code=22,Name="EF"}, new Subject(){
    Code=33,Name="UML"}}},

    new Student(){
        ID=2, FirstName="Mona", LastName="Gala",
    Subjects=new Subject []{ new Subject(){ Code=22,Name="EF"}, new Subject (){
    Code=34,Name="XML"},new Subject (){ Code=25, Name="JS"}}},
    new Student()
    { ID=3, FirstName="Yara", LastName="Yousf", 
        Subjects=new Subject[]{ new Subject (){ Code=22,Name="EF"}, 
        new Subject (){
    Code=25,Name="JS"}}},

    new Student(){
        ID=1, FirstName="Ali", LastName="Ali",
     Subjects=new Subject []{ new Subject (){ Code=33,Name="UML"}}},
};
Console.WriteLine("Query1: Display Full name and number of subjects for each student as follow\r\n");


students.Select(x=> new { FullName = $"{x.FirstName} {x.LastName}", NumberOfSubjects = x.Subjects.Length })
    .PrintList();

Console.WriteLine("\n_______________________________________________\n");

Console.WriteLine("Query2: Write a query which orders the elements in the list by FirstName\r\nDescending then by LastName Ascending and result of query displays only first\r\nnames and last names for the elements in list as follow");
students.Select(x => new { x.FirstName, x.LastName })
    .OrderByDescending(x=> x.FirstName)
    .OrderBy(x=>x.LastName).PrintList();

Console.WriteLine("\n_______________________________________________\n");

Console.WriteLine("Display each student and student’s subject as follow (use selectMany)");

students.SelectMany(x => x.Subjects.Select(s => new { StudentName = $"{x.FirstName} {x.LastName}", SubjectName = s.Name }))
    .PrintList();

Console.WriteLine("\n_______________________________________________\n");


var s = students.SelectMany(x => x.Subjects.Select(s => new { StudentName = $"{x.FirstName} {x.LastName}", SubjectName = s.Name }))
    .GroupBy(x => x.StudentName);

foreach (var group in s)
{
    Console.WriteLine(group.Key);
    foreach (var item in group)
    {
        Console.WriteLine($"    {item.SubjectName}");
    }
}


public static class Extensions
{
    public static void PrintList<T>(this IEnumerable<T> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}