using System;

public class Program
{
    public static double CalculateArea(double radius)
    {
        double area = Math.PI * radius * radius;
        return Math.Round(area, 2, MidpointRounding.AwayFromZero);
    }

    public static void Main(string[] args)
    {
        double radius = double.Parse(Console.ReadLine());
        double result = CalculateArea(radius);
        Console.WriteLine(result);
    }
}
