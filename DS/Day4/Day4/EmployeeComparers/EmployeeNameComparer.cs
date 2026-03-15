using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace Day4
{
    public class EmployeeNameComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Name.CompareTo(y.Name);
        }

    }

}