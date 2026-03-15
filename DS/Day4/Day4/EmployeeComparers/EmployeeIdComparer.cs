using System.Collections.Generic;

namespace Day4
{
    public class EmployeeIdComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            if (x == null) return -1;
            if (y == null) return 1;
            return x.id.CompareTo(y.id);
        }


    }
}