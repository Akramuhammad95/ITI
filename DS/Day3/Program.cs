using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;


namespace Day3
{
    public class Program
    {
        static void Main(string[] args)
        {
            ArrayStack<int> stack1 = new ArrayStack<int>();
            stack1.Push(5);
            stack1.Push(6);
            Console.WriteLine(stack1.peak);
            Console.WriteLine(stack1.Pop());
            Console.WriteLine(stack1.peak);
            Console.WriteLine(stack1.getLength);


            string name = "hello";
            ArrayStack<char> reverseStringStack = new ArrayStack<char>();

            foreach (var c in name)
            {
                reverseStringStack.Push(c);
                Console.Write(reverseStringStack.peak);
            }
            Console.WriteLine();

            while (!reverseStringStack.isEmpty)
            {
                Console.Write(reverseStringStack.Pop());
            }
        }
    }
}
