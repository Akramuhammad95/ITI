
class Employee
{
    int _id;

    public Employee(int Id, int Age)
    {
        _id = Id;
        this.Age = Age;

    }
    public int Id => field;
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}".Trim(); //readonly property


    public int Age
    {
        private set
        {
            if (value >= 20 && value < 35) field = value;
            else throw new Exception("Age must be between 20 and 35");
        }
        get => field;
    }
    public string Password
    {
        private get => field; //must use field in get and set accessors to avoid infinite recursion
        set//write only property
        {
            if (value.Length >= 8) field = value;
            else throw new Exception("Password must be at least 8 characters long");
        }
    }

}

