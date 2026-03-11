using System;
using Day1;

class Program
{
    static void Main()
    {
        #region Create Employees
        // Add Employees

        Employee e1 = new Employee(1, 30, 5000, "IT");
        Employee e2 = new Employee(2, 28, 4500, "HR");
        Employee e3 = new Employee(3, 35, 7000, "Finance");
        Employee e4 = new Employee(4, 40, 9000, "Management");

        Console.WriteLine("========== DOUBLY LINKED LIST ==========");

        //DoublyLinkedList<Employee> empList = new DoublyLinkedList<Employee>();

        //#endregion

        //#region print employees
        //empList.AddFirst(e1);
        //empList.AddLast(e2);
        //empList.AddLast(e3);
        //empList.AddFirst(e4);

        //Console.WriteLine("Employees in List:");
        //Console.WriteLine(empList);

        //Console.WriteLine("Count = " + empList.Count);

        //#endregion

        //// Remove First
        //#region Methods
        ////empList.RemoveFirst();
        //Console.WriteLine("After RemoveFirst()");
        //Console.WriteLine(empList);

        //// Remove Last
        //empList.RemoveLast();
        //Console.WriteLine("After RemoveLast()");
        //Console.WriteLine(empList);

        //// Search
        //Console.WriteLine("Contains e2 ? " + empList.Contains(e2));

        //// Delete specific employee
        //empList.Delete(e2);
        //Console.WriteLine("After Delete(e2)");
        //Console.WriteLine(empList);

        ////insert first
        //Employee e5 = new Employee(5, 31, 90000, "Engineering");


        //empList.AddFirst(e5);
        //Console.WriteLine("inserting(e5) first");
        //Console.WriteLine(empList);
        #endregion

        #region stack

        Console.WriteLine("========== STACK ==========");

        Stack<Employee> empStack = new Stack<Employee>();

        empStack.Push(e1);
        empStack.Push(e2);
        empStack.Push(e3);

        Console.WriteLine("Top Employee:");
        Console.WriteLine(empStack.Peek());

        Console.WriteLine("Pop Employee:");
        Console.WriteLine(empStack.Pop());

        Console.WriteLine("New Top:");
        Console.WriteLine(empStack.Peek());

        #endregion

        #region queue

        Console.WriteLine("========== QUEUE ==========");
        Queue<Employee> empQueue = new Queue<Employee>();

        empQueue.Enqueue(e1);
        empQueue.Enqueue(e2);
        empQueue.Enqueue(e3);

        Console.WriteLine("Front Employee:");
        Console.WriteLine(empQueue.Peek());

        Console.WriteLine("Dequeue Employee:");
        Console.WriteLine(empQueue.Dequeue());

        Console.WriteLine("New Front:");
        Console.WriteLine(empQueue.Peek());
        #endregion
    }
}