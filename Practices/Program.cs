using System;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;
using System.Text.Json;

class User
{
    public int id;
    public string name;
}


class Program
{
    public static void Main()
    {
        //Student st = new Student();
        //st.Name = "Alice";
        //st.Password = "secure123";
        //st.StudentID = 101;
        //st.Marks = 85;
        //st.Age = 20;

        //Console.WriteLine($"Name: {st.Name}");
        //Console.WriteLine
        //Console.WriteLine("enter the text: ");
        //int n = int.Parse(Console.ReadLine());
        //Console.WriteLine("The is the value :" + n);
        //Func<int, int> squareLambda = x => x * x;



        // this the part of the Exception practices

        //try
        //{
        //    int[] numbers = { 1, 2, 3 };
        //    int result = numbers[2] / 0; // Multiple possible exceptions
        //    Console.WriteLine(result);
        //}
        //catch (DivideByZeroException ex)
        //{
        //    Console.WriteLine("Cannot divide by zero.");
        //}
        //catch (IndexOutOfRangeException ex)
        //{
        //    Console.WriteLine("Invalid array index.");
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("An unexpected error occurred: " + ex.Message);
        //}

        //string path = "data.txt";
        //File.WriteAllText(path, "File data is added ");
        //Console.WriteLine("data written to the file successfull");
        //string content = File.ReadAllText("data.txt");
        //Console.WriteLine(content);



        //using (StreamWriter writer = new StreamWriter("Log.txt"))
        //{
        //    writer.WriteLine("Application started");
        //    writer.WriteLine("Processing Data");
        //    writer.WriteLine("Application Ended");
        //}

        //using (StreamReader reader = new StreamReader("Log.txt"))
        //{
        //    string line;
        //    while((line = reader.ReadLine()) != null)
        //    {
        //        Console.WriteLine(line);
        //    }
        //}
        /*
         
        User user = new User
        {
            id = 1,
            name = "Aditya"
        };

        using (StreamWriter writer = new StreamWriter("User.txt"))
        {
            writer.WriteLine(user.id);
            writer.WriteLine(user.name);

            user.id = 2;
            user.name = "Anshika";
            writer.WriteLine(user.id);
            writer.WriteLine(user.name);
        }

        Console.WriteLine("Data filled and save successfully");
        using (StreamReader reader = new StreamReader("User.txt"))
        {
            string reading;
            while ((reading = reader.ReadLine()) != null)
            {
                Console.WriteLine($"Reading data from User: {reading}");
            }
        }
        Console.WriteLine("Process complete!");
         */
        //User user = new User { id = 2, name = "Bob" };
        //using (BinaryWriter writer = new BinaryWriter(File.Open("Wser.bin", FileMode.Create)))
        //{
        //    writer.Write(user.id);
        //    writer.Write(user.name);
        //}

        //Console.WriteLine("Binary user data saved");

        /*  FileInfo file = new FileInfo("dataa.txt");
          if (!file.Exists)
          {
              using (StreamWriter writer = file.CreateText())
              {
                  writer.WriteLine("Hello FileInfo Class");
              }
          }
          Console.WriteLine("File Name: "+ file.Name);
          Console.WriteLine("File Size: "+ file.Length + "bytes");
          Console.WriteLine("Created On: "+ file.CreationTime);
        
        
        
        DirectoryInfo dir = new DirectoryInfo("Log");
        if (!dir.Exists)
        {
            dir.Create();
        }
        Console.WriteLine("Directory Name: "+ dir.Name);
        Console.WriteLine("Full Name: "+ dir.FullName);
        Console.WriteLine("Created On "+dir.CreationTime);
        */


        User user = new User
        {
            id = 1,
            name = "Adi"
        };

        string json = JsonSerializer.Serialize(user);
        File.WriteAllText("user.json", json);
        Console.WriteLine("User serialized successfully");

    }
}