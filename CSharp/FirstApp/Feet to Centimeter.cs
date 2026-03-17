using System;
class FTOC
{
    public static void convertFeettoCm()
    {
        double feet, cm;
        Console.WriteLine("Enter the feets:");
        feet = Convert.ToDouble(Console.ReadLine());
        cm = 30.48 * feet;
        Console.WriteLine($"Conversion of the feettoCM: {cm}");
    }

}