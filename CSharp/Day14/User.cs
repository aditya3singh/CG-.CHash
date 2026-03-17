using System;
using System.IO;

class User
{
    public int Id;
    public string Name;
}

class Persist
{
    public static void persist()
    {
        User user = new User { Id = 1, Name = "Alice" };

        using (StreamWriter writer = new StreamWriter("user.txt"))
        {
            writer.WriteLine(user.Id);
            writer.WriteLine(user.Name);

            user.Id = 2;
            user.Name = "Bobji";

            writer.WriteLine(user.Id);
            writer.WriteLine(user.Name);
        }

        Console.WriteLine("data saved");
        User user1 = new User();
        using (StreamReader reader = new StreamReader("user.txt"))
        {
            user1.Id = int.Parse(reader.ReadLine());
            user1.Name = reader.ReadLine();
        }
        Console.WriteLine($"User loaded {user1.Id}, {user1.Name}");
    }
}