
class Program
{
    public static void Main(string[] args)
    {
        bool IsValid = false;

        int x = 255;
        int y= 254;
        int n1 = 0;
        int n2 = 50;

        Console.WriteLine(Add(5, 6, IsValid));  //function call 
        Console.WriteLine(devide(55, 655));

        Console.WriteLine(IsGreater(x,y));
        Console.WriteLine(IsGreater(n2, n1));


        if(IsGreater(n2, n1))
            Console.WriteLine("3mmar");






        //IsGreater


    }

    public static int Add(int a, int b, bool koko)
    {
        return a + b;
    }
    public static double devide(double x, double y)
    {
        return x / y;
    }

    public static bool IsGreater(int x , int y)
     {

        return x > y;
    
    }

    


}
