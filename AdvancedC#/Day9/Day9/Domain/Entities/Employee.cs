namespace Domain.Entities
{
    public enum Sex
    {
        M , F
    }
    public class Employee
    {
        public Employee(int sSN, string fName, string lName, int dNO, DateTime bDate, string address, Sex gender, decimal salary)
        {
            SSN = sSN;
            FName = fName;
            LName = lName;
            DNO = dNO;
            BDate = bDate;
            Address = address;
            Gender = gender;
            Salary = salary;
        }

        public int SSN { get; init; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int DNO { get; set; }
        public DateTime BDate { get; set; }
        public string Address { get; set; }

        public Sex Gender { set; get; } = Sex.M;

        public decimal Salary { get; private set; }




    }
}
