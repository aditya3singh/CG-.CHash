using System;

class BankAccount
{
    private int accountNo;
    private double balance;
    public static string BankName = "Hamara National Bank";

    public BankAccount(int accNo, double initialBalance)
    {
        accountNo = accNo;
        balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine("Amount deposited successfully.");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    public void Deposit(ref double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            amount = 0;
            Console.WriteLine("Amount deposited using ref.");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    public bool Withdraw(double amount, out string message)
    {
        if (amount <= 0)
        {
            message = "Invalid withdrawal amount.";
            return false;
        }

        if (amount > balance)
        {
            message = "Insufficient balance.";
            return false;
        }

        balance -= amount;
        message = "Withdrawal successful.";
        return true;
    }

    public void Display()
    {
        Console.WriteLine($"Bank Name  : {BankName}");
        Console.WriteLine($"Account No : {accountNo}");
        Console.WriteLine($"Balance    : ₹{balance}");
    }
}