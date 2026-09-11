using System;
using Day5;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using ConsoleApp1;


public static class Program
{
    public static void Main()
    {
        int[] arr = { 1, 5, 6, 8, 5, 4, 8, 6 };


        for (int i = 0; i < arr.Length; i++) //searching in array ===>> o(n)....
        {
            if (arr[i] == 8)
                Console.WriteLine(true);

        }
        Console.WriteLine(false);


        //20       adding 20  







        //"Fruit name is apple and Weight is 3");  // =  1
        //"Fruit name is orange and Weight is 20");  // =  2
        //"Fruit name is bananna and Weight is 50");  // =  3










        #region extension method
        int number = 12345;
        Console.WriteLine(number.Mirror());
        // returns 54321

        Console.WriteLine(int.test(number));

        #endregion
        Console.WriteLine("____________");

        var e1 = new Employee(1, "Alice", "HR", 50000);
        var e2 = new Employee(1, "Alice", "HR", 50000);

        Console.WriteLine(e1.GetHashCode());
        Console.WriteLine(e2.GetHashCode());

        Console.WriteLine(e1.Equals(e2));

        // Should return true since they have the same properties


        Console.WriteLine(e1.Equals(new Employee(1, "Alice", "HR", 50000))); //

        // Should return true since they have the same properties


        // use anonymous type to compare
        var anon1 = new { ID = 1, Name = "Alice", Department = "HR", Salary = 50000 };
        Console.WriteLine(anon1.GetHashCode());

        var anon2 = new { id = 1, Name = "Alice", Department = "HR", Salary = 50000 };

        Console.WriteLine(anon2.GetHashCode());

        Console.WriteLine(anon1.Equals(anon2));


        Console.WriteLine("_____________Task1_______________");
        var mylist = MyListMethod();

        Console.WriteLine("_____________Task2_______________");

        Console.WriteLine("a-");

        var email = "akramuhafamfsdaf@gdfgfdg.com";
        Console.WriteLine(email.IsValidEmail());

       

        Console.WriteLine("b-");

        List<int> nums = new List<int> { 10, 20, 30, 40, 50 };

        var result = nums.NumbersAboveAverage();

        Console.WriteLine("Above average numbers:");
        foreach (var n in result)
        {
            Console.WriteLine(n);
        }

        Console.WriteLine("c-");

        DateTime d1 = DateTime.Now;
        DateTime d2 = DateTime.Now.AddDays(-1);
        DateTime d3 = DateTime.Now.AddDays(1);
        DateTime d4 = new DateTime(2020, 5, 10);

        Console.WriteLine(d1.ToFriendlyDate()); // Today
        Console.WriteLine(d2.ToFriendlyDate()); // Yesterday
        Console.WriteLine(d3.ToFriendlyDate()); // Tomorrow
        Console.WriteLine(d4.ToFriendlyDate()); // 10/05/2020


        var zoo = new Zoo();

        IAnimal Akram = new Lion(15 , "Akram");
        var Lotfy = new Lion(25, "Lotfy");
        zoo.Add(Akram);
        zoo.Add(Lotfy);


        foreach ( var a in zoo)
        {
            Console.WriteLine(a); 
        }


    }
    extension(int x)
    {
        public int Mirror()
        {
            char[] digits = x.ToString().ToCharArray();
            Array.Reverse(digits);
            string reversed = string.Join("", digits);
            return int.Parse(reversed);
        }
        public static int test(int num)
        {

            return num.Mirror();// This will cause a compile-time error since Mirror is only defined for int
        }
    }


    //task1
    public static List<Dictionary<string, object>> MyListMethod()
    {
        var newList = new List<Dictionary<string, object>>();
        var Dict1 = new Dictionary<string, object>();
        Dict1["akram"] = "Muhammad";
        var dict2 = new Dictionary<string, object>();
        dict2["Ahmed"] = 25;
        newList.Add(Dict1);
        newList.Add(dict2);
        return newList;

    }


    //task2

    public static bool IsValidEmail(this string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        return Regex.IsMatch(email, pattern);
    }
    public static  IEnumerable<int> NumbersAboveAverage(this IEnumerable<int> numbers)
    {
        List<int> result = new List<int>();
        double average =numbers.Average();
        foreach (int number in numbers)
        {
            if(number > average)
            {
                result.Add(number);
            }
        }
        return result;

    }

    public static string ToFriendlyDate(this DateTime date)
    {
        DateTime today = DateTime.Today;

        if (date.Date == today)
            return "Today";

        if (date.Date == today.AddDays(-1))
            return "Yesterday";

        if (date.Date == today.AddDays(1))
            return "Tomorrow";

        return date.ToString("dd/MM/yyyy");
    }

}