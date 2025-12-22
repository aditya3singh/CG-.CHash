using System;

class Student
{
    
    private string name = "";
    private int age;
    private int marks;

    public string Name
    {
        get => name;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                name = value;
        }
    }

    public int Age
    {
        get => age;
        set
        {
            if (value > 0)
                age = value;
        }
    }

    public int Marks
    {
        get => marks;
        set
        {
            if (value >= 0 && value <= 100)
                marks = value;
        }
    }

    public int StudentId { get; set; }

    public string ResultStatus => marks >= 40 ? "Pass" : "Fail";
    private string password = "";
    public string Password
    {
        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length >= 6)
                password = value;
        }
    }

    public string RegistrationNumber { get; private set; }
    public Student(string regNo)
    {
        RegistrationNumber = regNo;
    }

    public int AdmissionYear { get; init; }

    public double Percentage => marks;  // Expression-bodied, read-only

    public void Display()
    {
        Console.WriteLine($"ID          : {StudentId}");
        Console.WriteLine($"Reg No      : {RegistrationNumber}");
        Console.WriteLine($"AdmissionYr : {AdmissionYear}");
        Console.WriteLine($"Name        : {Name}");
        Console.WriteLine($"Age         : {Age}");
        Console.WriteLine($"Marks       : {Marks}");
        Console.WriteLine($"Percentage  : {Percentage}%");
        Console.WriteLine($"Result      : {ResultStatus}");
    }
}
