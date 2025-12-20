using System.Globalization;
using System.Linq.Expressions;

class Program
{
    static void Main()
    {
        // PT.PrintTable();
        // Employee emp = new Employee();
        // emp.Name = "Aditya";
        // emp.Salary = 300000;

        // emp.DisplayDetails();

        // Wallet w = new Wallet(1000);

        // w.AddMoney(500);
        // w.AddMoney(200);

        // Console.WriteLine("Balance: " + w.GetBalance());

        int sum1 = Calculator.Add(10, 20);
        int sum2 = Calculator.Add(10, 20, 30);

        Console.WriteLine(sum1);
        Console.WriteLine(sum2);
    }
}