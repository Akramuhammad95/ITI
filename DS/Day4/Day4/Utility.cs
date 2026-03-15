using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public static class Utility<T>
    {
        public static void Swap(T  obj1 , T obj2)
        {
            T temp = obj1;
            obj1 = obj2;
            obj2 = temp;

        }
    }
}
