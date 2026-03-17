using System;

class LOTN
{
    public static void Largest()
    {
        int a, b, c;

        Console.WriteLine("Enter a:");
        a = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter b:");
        b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter c:");
        c = Convert.ToInt32(Console.ReadLine());

        if (a > b && a > c)
            Console.WriteLine("a is largest");
        else if (b > c)
            Console.WriteLine("b is largest");
        else
            Console.WriteLine("c is largest");
    }
}
