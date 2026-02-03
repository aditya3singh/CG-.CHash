using System;

public class Program
{
    public decimal Balance { get; set; }

    public Program(decimal initialBalance)
    {
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new Exception("Deposit amount cannot be negative");
        }

        Balance = Balance + amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            throw new Exception("Insufficient funds");
        }

        Balance = Balance - amount;
    }

    public static void Main(string[] args)
    {
        Program account = new Program(1000);

        Console.WriteLine("Initial Balance: " + account.Balance);

        account.Deposit(500);
        Console.WriteLine("Balance after deposit: " + account.Balance);

        account.Withdraw(300);
        Console.WriteLine("Balance after withdrawal: " + account.Balance);
    }
}