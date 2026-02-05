using System;

public class solution
{
    public static string displayheight(int heightcm)
    {
        if (heightcm < 150)
        {
            return "Short";
        }
        else if (heightcm < 180)
        {
            return "Average";
        }
        else
        {
            return "Tall";
        }
    }

    public static void Main()
    {
        int heightcm = int.Parse(Console.ReadLine());
        string result = displayheight(heightcm);
        Console.WriteLine(result);
    }
}

