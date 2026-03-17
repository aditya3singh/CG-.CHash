using System;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using System.Xml.Serialization;

//class Program
//{
//    static void Main()
//    {
//        FileInfo file = new FileInfo("sample.txt");

//        if (!file.Exists)
//        {
//            using (StreamWriter writer = file.CreateText())
//            {
//                writer.WriteLine("Hello FileInfo Class");
//            }
//        }

//        Console.WriteLine("File Name: " + file.Name);
//        Console.WriteLine("File Size: " + file.Length + " bytes");
//        Console.WriteLine("Created On: " + file.CreationTime);
//    }
//}


//static void Main()
//{
//    DirectoryInfo dir = new DirectoryInfo("Logs");

//    if (!dir.Exists)
//    {
//        dir.Create();
//    }

//    Console.WriteLine("Directory Name:" + dir.Name);
//    Console.WriteLine("Created On:" + dir.CreationTime);
//    Console.WriteLine("Full PathS:" + dir.FullName);
//}



//class Program
//{
//    static void Main()
//    {
//        User user = new User { Id = 1, Name = "Alice" };
//        string json = JsonSerializer.Serialize(user);

//        File.WriteAllText("user.json", json);
//        Console.WriteLine("User serialization successfully");
//    }
//}




//class Program
//{
//    static void Main()
//    {
//        string json = File.ReadAllText("user.json");
//        User user = JsonSerializer.Deserialize<User>(json);
//        Console.WriteLine($"User Loaded: {user.Id}, {user.Name}");
//    }
//}
public class Program
{
    static void Main()
    {
        User user = new User { Id = 1, Name = "Alice" };

        XmlSerializer serializer = new XmlSerializer(typeof(User));

        using (FileStream fs = new FileStream("user.xml", FileMode.Create))
        {
            serializer.Serialize(fs, user);
        }

        Console.WriteLine("XML Serialized");
    }
}