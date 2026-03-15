using System;

namespace Day4
{
    public class Employee : IComparable<Employee>
    {
        public string Name { get; }
        public DateTime HireDate { get; }

        public int id { get; }

        public static int nextId = 1;

        public Employee(string Name, DateTime HireDate)
        {
            this.Name = Name;
            this.HireDate = HireDate;
            id = nextId++;
        }

        public Employee()
        {
            
        }

        public int CompareTo(Employee other)
        {
            if (other == null) return 1;
            return this.HireDate.CompareTo(other.HireDate);
        }

        public static bool operator <(Employee e1, Employee e2)
        {
            return e1.HireDate < e2.HireDate;
        }

        // Overload >
        public static bool operator >(Employee e1, Employee e2)
        {
            return e1.HireDate > e2.HireDate;
        }

        // Overload ==
        public static bool operator ==(Employee e1, Employee e2)
        {
            if (ReferenceEquals(e1, e2)) return true;
            if (ReferenceEquals(e1, null) || ReferenceEquals(e2, null)) return false;
            return e1.HireDate == e2.HireDate;
        }

        // Overload != (must be done if == is overloaded)
        public static bool operator !=(Employee e1, Employee e2)
        {
            return !(e1 == e2);
        }

        // Override Equals and GetHashCode when overloading ==
        public override bool Equals(object obj)
        {
            if (obj is Employee other)
                return this.HireDate == other.HireDate;
            return false;
        }

        public override string ToString()
        {
            return $" ID {this.id} , Name {this.Name} , Hire date {this.HireDate}";
        }
        public override int GetHashCode()
        {
            return HireDate.GetHashCode();
        }
    }
}