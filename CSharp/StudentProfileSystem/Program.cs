class Program
{
    static void Main()
    {
        Student s = new Student();
        s.Name = "Aditya";
        s.Age = 23;
        s.Marks = 34;

        Console.WriteLine("Name := "+ s.Name);
        Console.WriteLine("Name := "+ s.Age);
        Console.WriteLine("Name := "+ s.Marks);
    }
}
