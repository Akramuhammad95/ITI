using System;

class Program
{
    static void Main()
    {
        int m = int.Parse(Console.ReadLine());

        var l1 = Console.ReadLine().Split();
        int h1 = int.Parse(l1[0]);
        int a1 = int.Parse(l1[1]);

        var l2 = Console.ReadLine().Split();
        int x1 = int.Parse(l2[0]);
        int y1 = int.Parse(l2[1]);

        var l3 = Console.ReadLine().Split();
        int h2 = int.Parse(l3[0]);
        int a2 = int.Parse(l3[1]);

        var l4 = Console.ReadLine().Split();
        int x2 = int.Parse(l4[0]);
        int y2 = int.Parse(l4[1]);

        int seconds = 0;

        while (seconds <= 10000)
        {
            if (h1 == a1 && h2 == a2)
            {
                Console.WriteLine(seconds);
                return;
            }

            h1 = (h1 * x1 + y1) % m;
            h2 = (h2 * x2 + y2) % m;

            seconds++;
        }

        Console.WriteLine(-1);
    }
}