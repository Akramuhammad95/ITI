using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public abstract class IAnimal
    {
        public int id;
        public string Name;

    
        protected IAnimal(int id, string name)
        {
            this.id = id;
            Name = name;
        }
    }
}
