using System;

class EO
{
    public static void EODD()
    {
        int n;
        Console.WriteLine("Enter the n: ");
        n = Convert.ToInt32(Console.ReadLine());

        if(n % 2 == 0)
        {
            Console.WriteLine("This number is even");
        }
        else
        {
            Console.WriteLine("Enter the even number other wise this one is aslo fine but is Odd");
        }
    }
}