using System;

class Program
{
    static void SwapRef(ref int a, ref int b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }

    static void Main()
    {
        int x = 10, y = 20;

        SwapRef(ref x, ref y);

        Console.WriteLine(x + " " + y);
    }
}
