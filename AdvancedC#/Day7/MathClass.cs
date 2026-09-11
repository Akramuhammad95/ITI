using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public static class MathClass
    {
        public static int num1 { get; set; }
        public static int num2 { get; set; }

        public static int AddResult { get; set; }

        public static int FactorialResult { get; set; } = 1;
        public static int FactorialInput { get; set; }

        public static void Factorial()
        {
            Console.WriteLine("Factorial method");

            int num = 0;
            while (num++ < FactorialInput)
            {
                FactorialResult *= num;
                Console.WriteLine(FactorialResult);

            }
            Thread.Sleep(2000);
            Console.WriteLine("The result method");

            Console.WriteLine(FactorialResult); FactorialResult = 1;


        }
        public static void Sum()
        {
            Console.WriteLine("Sum Method:");
            AddResult = num1 + num2;
            Console.WriteLine(AddResult); AddResult = 1;
        }
    }
}
