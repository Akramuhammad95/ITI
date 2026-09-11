using Day6;
using System.Reflection;
using System.Text;
using static Day6.EmployeeSalaryService;

class Program
{
    public static void Main()
    {
        #region Task 1

        Employee ziad = new Employee(55000)
        {
            Id = 1,
            Address = "banha",
            Description = "son of akram",
            Name = "ziad",
            Title="Kid"
        };

        Console.WriteLine("1.b.c------------------");

        EmployeeSalaryService ziadSalaryService = new EmployeeSalaryService();
        ziadSalaryService.UpdateSalary(ziad, 0.25);
        Console.WriteLine("1.c------------------");
     
        TextStyling style = TextStyling.Bold | TextStyling.Italic;
        Console.WriteLine(style);

        bool hasUnderline = style.HasFlag(TextStyling.Underline);
        Console.WriteLine($"Underline applied? {hasUnderline}");


        //Type type = typeof(Employee);

        //Console.WriteLine(type);
        #endregion

        #region task 2
        Console.WriteLine("\n\n\n\nTask 2 \n");

        Console.WriteLine(ziad.GetType());

        var type = typeof(DiscountService);
        var attributes = (StereoTypeAttribute[])type.GetCustomAttributes(typeof(StereoTypeAttribute), false);

        foreach (var attr in attributes)
        {
            Console.WriteLine($"StereoType: {attr.Name}, Description: {attr.Description}");
        }
        #endregion

        #region task 3
        Console.WriteLine("\n\n\n\nTask 3\n");

        Type t = typeof(int);

        Console.WriteLine($"Name: {t.Name}");
        Console.WriteLine($"Namespace: {t.Namespace}");
        Console.WriteLine($"Is Primitive: {t.IsPrimitive}");
        Console.WriteLine($"Is Value Type: {t.IsValueType}");
        Console.WriteLine($"Is Class: {t.IsClass}");


        #endregion


        #region 4
        Console.WriteLine("\n\n\n\nTask 4\n");
        Type EmpType=typeof(Employee);

        Console.WriteLine($"Name: {t.Name}");
        Console.WriteLine($"Namespace: {t.Namespace}");
        Console.WriteLine($"Is Primitive: {t.IsPrimitive}");
        Console.WriteLine($"Is Value Type: {t.IsValueType}");
        Console.WriteLine($"Is Class: {t.IsClass}");
        #endregion

        #region 5
        //Console.WriteLine("\n\n\n\nTask 5 \n");
        //Console.WriteLine("Enter the class name");
        //string s = Console.ReadLine();
        //var assem=Assembly.GetExecutingAssembly();
        //Type type2 = assem.GetType("Day6."+s);
        //object obj1 = Activator.CreateInstance(type2,5000m);

        //var prop = obj1.GetType().GetProperties();
     

        //foreach(var i in prop)
        //{
        //    Console.Write($"Enter value for {i.Name}: ");
        //    string input = Console.ReadLine();

        //    try
        //    {
        //        object value = Convert.ChangeType(input, i.PropertyType);

        //        i.SetValue(obj1, value);
        //    }
        //    catch
        //    {
        //        Console.WriteLine($"Invalid value for {i.Name}");
        //    }
        //}


        #endregion
        #region 6
        Console.WriteLine("\n\n\n\nTask 6 \n");

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append( "Hello ");
        stringBuilder.Append("Lotfy ");
        stringBuilder.Append("You  are ");
        stringBuilder.Append("amazing ");
        stringBuilder.Replace("amazing ",".");
        Console.WriteLine(stringBuilder.ToString());






        #endregion

        #region 7
        Console.WriteLine("\n\n\n\nTask 7\n");

        ConsoleLogger.Instance.Logging("start logging");
        ConsoleLogger.Instance.Logging("Ziad Akram");

        #endregion



    }
}

[Flags]
public enum TextStyling
{
    None = 0,
    Bold = 1,
    Italic = 2,
    Underline = 4,
    Strikethrough = 8
}


/*
 1.	Try the pre-defined Attributes:
a.	CLSAttribute.
b.	ObsoleteAttribute (in both cases true and false).
c.	FlagAttribute (with TextStyling Enum).
2.	Try to make Custom attribute “StereoType” that has the following attributes:
a.	Type (Accessor, Modifier, Class …).
b.	Description.
I.	Apply this Attribute to class person.
II.	Query this attribute with reflections and display its data.
3.	Try to view the metadata of any primitive type of your choice.
4.	Try to view the metadata of class person (User define class).
5.	Create object from Student class at run time.
a.	Name.
b.	Age.
c.	Grade.(apply Enum A,B,C,D) and try to use it and print
d.	Address.
-------------------------------------------------
Write a C# console program that uses StringBuilder to do the following:

Create a StringBuilder object
Add the text "Hello" using Append()
Add " Students" using AppendLine()
Insert the word "Amazing " after "Hello" using Insert()
Replace "Students" with your name using Replace()
Remove the word "Amazing " using Remove()
Print the final result using ToString()
----------------------------------------------------------
Create custom Exception and use it in your own logic 
------------------------------------------------------
give me example for using static constructor and static method
*/

