using System;
using System.Collections.Generic;
using System.Text;

namespace Day2.Animals
{
    public class Sparrow : Animal
    {
        public Sparrow(int Age, string Name) : base(Age, Name)
        {
        }
         public void Chirp() => Console.WriteLine("The Animal chirps");
    
    }
}
