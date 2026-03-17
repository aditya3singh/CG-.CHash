using System;
using System.IO;

class Program
{
    static void Main()
    {
        using StreamReader reader = new StreamReader("log.txt");
        using StreamWriter writer = new StreamWriter("error.txt");

        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            if (line.Contains("ERROR"))
            {
                writer.WriteLine(line);
            }
        }

        Console.WriteLine("ERROR logs written to error.txt");
    }
}
