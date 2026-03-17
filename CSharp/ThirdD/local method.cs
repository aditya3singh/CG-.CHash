using System;

class LM
{
    //  public static void Calculator(int a, int b)
    // {
    //     int Add()
    //     {
    //         return a + b;
    //     }

    //     int Subtract()
    //     {
    //         return a - b;
    //     }

    //     Console.WriteLine("Add = " + Add());
    //     Console.WriteLine("Subtract = " + Subtract());
    // }
    static int number = 5;

    public static void Calculate()
    {
        static int Square(int x)
        {
            return x * x;
        }

        Console.WriteLine(Square(number));
    }
}
