using System;

class Person
{
    protected string name;
    protected int age;

    // Parent constructor with parameters
    public Person(string n, int a)
    {
        name = n;
        age = a;
    }

    public void ShowPerson()
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age : " + age);
    }
}
