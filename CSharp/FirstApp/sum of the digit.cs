//sum of the digit
using System;

class SumOfDigit
{
    public static void SOD()
    {
        int n, sum = 0, r;
        Console.WriteLine("Enter a number:");
        n = Convert.ToInt32(Console.ReadLine());
        while (n != 0)
        {
            r = n % 10;
            sum += r;
            n /= 10;
        }
        Console.WriteLine("Sum of digits is: " + sum);
    }
}
