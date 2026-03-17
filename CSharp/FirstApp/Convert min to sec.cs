using System;
class CMTS
{
    public static void ConvertMTS()
    {
        int min, sec;
        Console.WriteLine("Enter the min: ");
        min = Convert.ToInt32(Console.ReadLine());
        sec = 60 * min;
        if(sec >= 300)
        {
        Console.WriteLine($"this is the conversion : {sec}");
        }
        else
        {
            Console.WriteLine("You should have to take input for min more than 5 ");
        }
    }
}