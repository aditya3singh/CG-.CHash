using System;
using System.Collections.Generic;

class Student : IComparable<Student>
{
    public string name;
    public int age;
    public int marks;

    public Student(string name, int age, int marks)
    {
        this.name = name;
        this.age = age;
        this.marks = marks;
    }

    public int CompareTo(Student other)
    {
        if (this.marks != other.marks)
            return other.marks.CompareTo(this.marks);

        return this.age.CompareTo(other.age);
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student("Amit", 21, 90),
            new Student("Rahul", 19, 90),
            new Student("Neha", 20, 85),
            new Student("Priya", 18, 95)
        };

        students.Sort();

        foreach (var s in students)
        {
            Console.WriteLine($"{s.name} - {s.marks} - {s.age}");
        }
    }
}
