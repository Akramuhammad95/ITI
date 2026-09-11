using System;
using System.Collections.Generic;
using System.Text;

namespace Day2.Animals
{
    internal class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message): base(message)
        {
            
        }

    }
}
