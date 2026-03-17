using System;
using System.Reflection.Metadata;

public class Program
{
    public static void Main()
    {
        /*
         
        (int, string) st1 = (101, "Amit");
        var st2 = (Id: 101, Name: "Amit");

        var st3 = new { Id = 101, Name = "Amit" };

        Console.WriteLine(st1.GetType());
        Console.WriteLine(st2.GetType());
        Console.WriteLine(st3.GetType());

        var result = Calculate(10, 20);

        Console.WriteLine($"Sum = {result.sum}");
        Console.WriteLine($"Average = {result.calculator}");

        static (int sum , int calculator) Calculate(int a, int b)
        {
            return (a + b, (a + b) / 2);
        }
         */
        /*
        static(bool IsValid, string Message) ValidateUser(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return (false, "Username is required");
            }
            return (true, "Valid user");
        }

        var response = ValidateUser("Admin");
        Console.WriteLine(response.Message);

        */
        /*
        var person = (Id: 1, Name: "Neha");
        Console.WriteLine(person.Id);

        var (id, name) = person;
        Console.WriteLine(id);
        Console.WriteLine(id.GetType());

        var (_, userName) = person;
        Console.WriteLine(userName);
        */
        /*
        public int Id { get; set; }
        public string Name { get; set; }
        public void Deconstruct(out int id, out string name) { id = Id; name = Name; }

        var s = new Program { Id = 1, Name = "Amit" }; s.GetType() var (sid, sname) = s; Console.WriteLine(sid); Console.WriteLine(sname);
        */
        /*
        int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8 };

        var result = nums
                        .Where(n => n > 3)
                        .Select(n => n * 2);

        foreach (var n in result)
        {
            Console.WriteLine(n);
        }
        */
        /*
        var students = new List<Student>
        {
            new Student { Name = "Amit", Grade = 'A', Marks = 75 },
            new Student { Name = "Neha", Grade = 'B', Marks = 58 },
            new Student { Name = "Rahul", Grade = 'A', Marks = 40 }
        };

   
        var result = students.Select(s => new
        {
            s.Name,
            Result = s.Marks > 60 ? "Pass" : "Fail"
        }).ToList();

        // Display output
        foreach (var item in result)
        {
            Console.WriteLine($"{item.Name} : {item.Result}");
        }

        Console.WriteLine(result.GetType());
        */

        /*
        List<int> numbers = new List<int> { 5, 2, 8, 1, 3 };

        var ascending = numbers.OrderBy(n => n);
        var descending = numbers.OrderByDescending(n => n);

        Console.WriteLine("Ascending:");
        foreach (var n in ascending)
        {
            Console.WriteLine(n);
        }

        Console.WriteLine("Descending:");
        foreach (var n in descending)
        {
            Console.WriteLine(n);
        }
        */
        /*
        using(ManifestResourceHandle handler = new ResourceHandler())
        {
            Console.WriteLine("Using resource...");
        }
        Console.WriteLine("End of Program");
        */


        Console.WriteLine($"Total Memory Before GC: {GC.GetTotalMemory(false)} bytes");

        for (int i = 0; i < 10000; i++)
        {
            object obj = new object(); // Gen 0 allocation
        }

        Console.WriteLine($"Total Memory After Object Creation: {GC.GetTotalMemory(false)} bytes");

        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine($"Total Memory After GC: {GC.GetTotalMemory(false)} bytes");
        Console.WriteLine($"Generation of a new object: {GC.GetGeneration(new object())}");
    }
}
