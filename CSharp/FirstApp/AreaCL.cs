//Area of Circle
using System;
class AreaOCircle
{
    public static void CalculateArea()
    {
        double radius, area;
        Console.WriteLine("Enter the radius of the circle:");
        radius = Convert.ToDouble(Console.ReadLine());
        area = Math.PI * radius * radius;
        Console.WriteLine("Area of the circle is: " + area);
    }
}