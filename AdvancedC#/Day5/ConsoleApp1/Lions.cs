using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Lion : IAnimal
    {
        public Lion(int id, string name) : base(id, name)
        {
        }
        public override string ToString()
        {
            return $"Name = {Name}";
        }
    }
}
