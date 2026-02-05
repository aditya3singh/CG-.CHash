using System;

public class solution
{
    public static double feettocentimeters(int feet)
    {
        double centimeters = feet * 30.48;
        return Math.Round(centimeters, 2, MidpointRounding.AwayFromZero);
    }

    public static void Main()
    {
        int feet = int.Parse(Console.ReadLine());
        double result = feettocentimeters(feet);
        Console.WriteLine(result);
    }
}
