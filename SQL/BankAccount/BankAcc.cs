using System;

class BankAcc
{
    private int accountNo;
    private int balance;
    public static string BankName = "ABC International Bank";

    public BankAcc(int aN, int bal)
    {
        accountNo = aN;
        balance = bal;
    }

    public static void Deposit(double amount)
    {
        if(amount > 0)
        {
            balance += amount;
            amount = 0;
            Console.WriteLine("Balance added successfully");
        }
        Console.WriteLine("Invalid details");
    }
    public static void Withdraw(ref )
    {
        
    }

    public static void Display()
    {

    }
}