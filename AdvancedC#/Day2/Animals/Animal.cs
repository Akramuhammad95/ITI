using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Text;

namespace Day2.Animals
{
    public abstract class Animal
    {
        protected int _age;
        protected string _name;


        protected Animal() { }

        public int Age=>_age;
        public string Name => _name;
        public Animal(int Age , string Name )
        {
            _age = Age;
            _name = Name;
        }
    }

}
