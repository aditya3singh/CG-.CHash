using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name;
    public string Grade;
    public int Marks;
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student { Name = "Aryan", Marks = 75 },
            new Student { Name = "Mohit", Marks = 45 },
            new Student { Name = "Sushant", Marks = 90 },
            new Student { Name = "Ritik", Marks = 55 }
        };

        // LINQ SELECT (PASS / FAIL)
        var result = students.Select(s => new
        {
            s.Name,
            Grade = s.Marks > 60 ? "Pass" : "Fail"
        });

        foreach (var item in result)
        {
            Console.WriteLine($"Name: {item.Name}, Grade: {item.Grade}");
        }

        Console.WriteLine("----- Sorted By Name -----");

        // LINQ ORDER BY
        var sortedByName = students.OrderBy(e => e.Name);

        foreach (var item in sortedByName)
        {
            Console.WriteLine($"Name: {item.Name}, Marks: {item.Marks}");
        }

        // SORT BY MARKS
        var sortedByMarks = students.OrderBy(s => s.Marks);

        // TAKE LAST ELEMENT
        var lastStudent = sortedByMarks.Last();

        Console.WriteLine("Student with highest marks:"+sortedByMarks);
        Console.WriteLine($"Name: {lastStudent.Name}, Marks: {lastStudent.Marks}");
    }
}
