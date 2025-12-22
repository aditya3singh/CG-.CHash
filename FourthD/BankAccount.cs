using System;

class BankAccount
{
    protected double balance;
    public BankAccount(double initialBalance)
    {
        balance = initialBalance;
        Console.WriteLine("Parent Constructor: BankAccount initialized");
    }
    public void Deposit(double amount)
    {
        balance += amount;
        Console.WriteLine("Deposited: " + amount);
    }
}
