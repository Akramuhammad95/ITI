using System;
using System.Collections.Generic;
using System.Text;

namespace Day6
{
    public class ConsoleLogger : Ilogger
    {
        private static ConsoleLogger _instance;
        static ConsoleLogger()
        {
            _instance = new ConsoleLogger();
        }
        private ConsoleLogger()
        {
            Console.WriteLine("Logger is created");  
        }
         
        public static ConsoleLogger Instance => _instance;

        public void Logging(string message)
        {
            Console.WriteLine($"Logging {message}");
        }

    }
}
