using System;

class RN
{
    public static void RevNum()
    {
        int number, reverse = 0;
        Console.WriteLine("Enter the num");
        number = Convert.ToInt32(Console.ReadLine());

        while (number > 0)
        {
            int digit = number % 10;
            reverse = reverse * 10 + digit;
            number /= 10;
        }
        Console.WriteLine(reverse);
    }
}