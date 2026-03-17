using System;
using System.Reflection.Metadata;

class Program
{
    public static void Main()
    {
        //string path = "data.txt";
        /*
        File.WriteAllText(path, "File I/O Example in C#");

        File.WriteAllText(path, "file replace");
        Console.WriteLine("Datawritten in File");
        */

        //string content = File.ReadAllText("data.txt");
        //Console.WriteLine("File Content");

        //using (StreamWriter writer = new StreamWriter("log.txt"))
        //{
        //    writer.WriteLine("Application Started");
        //    writer.WriteLine("Processing Data");
        //    writer.WriteLine("Application Ended");
        //}
        //using (StreamReader reader = new StreamReader("log.txt"))
        //{
        //    string line;
        //    while((line = reader.ReadLine()) != null)
        //    {
        //        Console.WriteLine(line);
        //    }
        //}


        //Persist.persist();

        User user = new User
        {
            Id = 2,
            Name = "Bob"
        };

        using (BinaryWriter writer = new BinaryWriter(
            File.Open("user.bin", FileMode.Create)))
        {
            writer.Write(user.Id);
            writer.Write(user.Name);
        }

        Console.WriteLine("Binary user data saved.");


        using (BinaryReader reader = new BinaryReader(File.Open("user.bin", FileMode.Open)))
        {
            Console.WriteLine(reader.ReadInt32());
            Console.WriteLine(reader.ReadString());
        }
    }
}