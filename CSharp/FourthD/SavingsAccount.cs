using System;

class SavingsAccount : BankAccount
{
    public SavingsAccount(double initialBalance)
        : base(initialBalance)
    {
        Console.WriteLine("Child Constructor: SavingsAccount initialized");
    }
    public void ShowBalance()
    {
        Console.WriteLine("Current Balance: " + balance);
    }
}

