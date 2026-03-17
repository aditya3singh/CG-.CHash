using System;

class Employee
{
    public string Name = "";
    public double Salary;

    public void DisplayDetails()
    {
        Console.WriteLine(Name + " earns " + Salary);
    }
}
