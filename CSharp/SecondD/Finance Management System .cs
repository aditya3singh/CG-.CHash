using System;

class FMS
{
    public static void FinanceManagementSystem()
    {
        while (true)
        {
            Console.WriteLine("...Finance Management System...");
            Console.WriteLine("1. Debit Operations");
            Console.WriteLine("2. Credit Operations");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DebitMenu();
                    break;

                case 2:
                    CreditMenu();
                    break;

                case 3:
                    Console.WriteLine("Program terminated.");
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
    static void DebitMenu()
    {
        Console.WriteLine("Debit Operations...");
        Console.WriteLine("1. ATM Withdrawal Limit Check");
        Console.WriteLine("2. EMI Burden Evaluation");
        Console.WriteLine("3. Daily Spending Calculator");
        Console.WriteLine("4. Minimum Balance Check");
        Console.Write("Enter your choice: ");

        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                Debit.ATMWithdrawalLimit();
                break;
            case 2:
                Debit.EMIBurden();
                break;
            case 3:
                Debit.DailySpending();
                break;
            case 4:
                Debit.MinimumBalance();
                break;
            default:
                Console.WriteLine("Invalid debit option!");
                break;
        }
    }
    static void CreditMenu()
    {
        Console.WriteLine("...Credit Operations...");
        Console.WriteLine("1. Net Salary Calculation");
        Console.WriteLine("2. Fixed Deposit Maturity");
        Console.WriteLine("3. Reward Points Calculation");
        Console.WriteLine("4. Bonus Eligibility Check");
        Console.Write("Enter your choice: ");

        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                Credit.NetSalary();
                break;
            case 2:
                Credit.FixedDeposit();
                break;
            case 3:
                Credit.RewardPoints();
                break;
            case 4:
                Credit.BonusEligibility();
                break;
            default:
                Console.WriteLine("Invalid credit option!");
                break;
        }
    }
}
class Debit
{
    public static void ATMWithdrawalLimit()
    {
        const int limit = 40000;
        Console.Write("Enter withdrawal amount: ");
        int amount = Convert.ToInt32(Console.ReadLine());

        if (amount <= limit)
            Console.WriteLine("Withdrawal permitted within daily limit.");
        else
            Console.WriteLine("Daily ATM withdrawal limit exceeded.");
    }

    public static void EMIBurden()
    {
        Console.Write("Enter monthly income: ");
        double income = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter EMI amount: ");
        double emi = Convert.ToDouble(Console.ReadLine());

        if (emi <= income * 0.40)
            Console.WriteLine("EMI is financially manageable.");
        else
            Console.WriteLine("EMI exceeds safe income limit.");
    }

    public static void DailySpending()
    {
        Console.Write("Enter number of transactions: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double total = 0;

        for (int i = 1; i <= n; i++)
        {
            Console.Write($"Enter transaction {i}: ");
            total += Convert.ToDouble(Console.ReadLine());
        }

        Console.WriteLine("Total debit amount for the day: ₹" + total);
    }

    public static void MinimumBalance()
    {
        const int minBalance = 2000;
        Console.Write("Enter current balance: ");
        int balance = Convert.ToInt32(Console.ReadLine());

        if (balance < minBalance)
            Console.WriteLine("Minimum balance not maintained. Penalty applicable.");
        else
            Console.WriteLine("Minimum balance requirement satisfied.");
    }
}
class Credit
{
    public static void NetSalary()
    {
        Console.Write("Enter gross salary: ");
        double gross = Convert.ToDouble(Console.ReadLine());

        double net = gross - (gross * 0.10);
        Console.WriteLine("Net salary credited: ₹" + net);
    }

    public static void FixedDeposit()
    {
        Console.Write("Enter principal: ");
        double p = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter rate of interest: ");
        double r = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter time (years): ");
        double t = Convert.ToDouble(Console.ReadLine());

        double si = (p * r * t) / 100;
        Console.WriteLine("Fixed Deposit maturity amount: ₹" + (p + si));
    }

    public static void RewardPoints()
    {
        Console.Write("Enter total credit card spending: ");
        int spending = Convert.ToInt32(Console.ReadLine());

        int points = spending / 100;
        Console.WriteLine("Reward points earned: " + points);
    }

    public static void BonusEligibility()
    {
        Console.Write("Enter annual salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter years of service: ");
        int years = Convert.ToInt32(Console.ReadLine());

        if (salary >= 500000 && years >= 3)
            Console.WriteLine("Employee is eligible for bonus.");
        else
            Console.WriteLine("Employee is not eligible for bonus.");
    }
}
