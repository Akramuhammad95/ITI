using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Day2
{
    public class UserDescComparer : IComparer<User>
    {
      
        public int Compare(User? x, User? y)=> y.age.CompareTo(x.age);
    }
}
