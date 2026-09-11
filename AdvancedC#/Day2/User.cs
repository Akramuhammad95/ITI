using System;
using System.Collections.Generic;
using System.Text;

namespace Day2
{
    public class User : IComparable
    {

        public int id { get; set; }
        public int age { get; set; }

        string name { get; set; }

        public int CompareTo(object? obj)
        {
            User user = obj as User;
            return this.age.CompareTo(user.age);
        }
    }
}
