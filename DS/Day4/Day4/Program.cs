using System;
using System.Collections.Generic;
using Day4.Searchers;
namespace Day4
{

    class Program
    {
        static void Main()
        {
            #region Search and sort
            var employees = new List<Employee>
        {
            new Employee("Ali", new DateTime(2022, 1, 15)),
            new Employee("Akram", new DateTime(2023, 5, 1)),
            new Employee("Ziad", new DateTime(2024, 3, 10))
        };


            Console.WriteLine("Before Sorting:");
            employees.ForEach(e => Console.WriteLine(e));

            ISorter<Employee> sorter = new BubbleSorter<Employee>();
            sorter.Sort(employees, new EmployeeHireDateComparer());

            Console.WriteLine("\nAfter Sorting by HireDate:");
            employees.ForEach(e => Console.WriteLine(e));

            Console.WriteLine(" ===========binary search==========");
            var comparer = new EmployeeHireDateComparer();

            BinarySearch<Employee> searcher = new BinarySearch<Employee>(comparer);

            Employee target = new Employee("Akram", new DateTime(2023, 5, 1));

            int index = searcher.Search(employees, target);

            Console.WriteLine($"The Employee with  hire Date {target.HireDate} at index: " + index);

            #endregion


            //////////////////////////////////////////////////////////////
            Console.WriteLine("===========Sorted linked list======================");
            #region Sorted Linked list

            Console.WriteLine("input numbers : 5 , 7, 3");

            SortedLinkedList<int> sortedLinkedList = new SortedLinkedList<int>();
            sortedLinkedList.Add(5);
            sortedLinkedList.Add(7);
            sortedLinkedList.Add(3);


            Console.WriteLine(sortedLinkedList);
            Console.WriteLine("after insertion");


            #endregion




        }
    }
}