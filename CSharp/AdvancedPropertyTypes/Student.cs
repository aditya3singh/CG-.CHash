using System;

class Student
{
    private string name = "";
    private int age;
    private int marks;

    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                name = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value > 0)
                age = value;
        }
    }

    public int Marks
    {
        get { return marks; }
        set
        {
            if (value >= 0 && value <= 100)
                marks = value;
        }
    }

    public int StudentId { get; set; }

    public string ResultStatus
    {
        get
        {
            return marks >= 40 ? "Pass" : "Fail";
        }
    }
    private string password = "";

    public string Password
    {
        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length >= 6)
                password = value;
        }
    }

    public void Display()
    {
        Console.WriteLine($"ID     : {StudentId}");
        Console.WriteLine($"Name   : {Name}");
        Console.WriteLine($"Age    : {Age}");
        Console.WriteLine($"Marks  : {Marks}");
        Console.WriteLine($"Result : {ResultStatus}");
    }
}
