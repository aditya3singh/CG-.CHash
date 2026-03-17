/*

Design a Finance Control System that performs the following tasks:
Loan Eligibility Check
Income Tax Calculation
Transaction Entry System
Exit Program
The system should run continuously until the user chooses to exit.

Finance Rules Used

Loan Eligibility Rules
Age must be 21 years or above
Monthly income must be ₹30,000 or more


Income Tax Rules
Annual Income
Tax Rate
≤ ₹2,50,000
0%
₹2,50,001 – ₹5,00,000
5%
₹5,00,001 – ₹10,00,000
20%
Above ₹10,00,000
30%


Transaction Rules
User can enter 5 transactions

Negative amount is invalid

Invalid transactions should be skipped

Menu Design (Using switch-case)
1. Check Loan Eligibility
2. Calculate Tax
3. Enter Transactions
4. Exit

Program Flow
Program starts
Menu is displayed
User selects an option
Selected operation executes
Menu repeats until user exits



*/

using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

class FCS
{
    public static void FinanceControlSystem()
    {
        while (true)
        {
            Console.WriteLine("---Finance Control System---");
            Console.WriteLine("1. Check Loan Eligibility");
            Console.WriteLine("2. Calculate Income Tax");
            Console.WriteLine("3. Enter Transactions");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CheckLoanEligibility();
                    break;
                case 2:
                    CalculateIncomeTax();
                    break;
                case 3:
                    EnterTransactions();
                    break;
                case 4:
                    Console.WriteLine("Exiting program...");
                    return;

                default:
                    Console.WriteLine("Invalid choice! Try again");
                    break;
            }
        }
    }
    public static void CheckLoanEligibility()
    {
        int age, monthlyIcm;
        Console.WriteLine("Enter the age: ");
        age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the MonthlyIncome: ");
        monthlyIcm = Convert.ToInt32(Console.ReadLine());

        if(age >= 20 && monthlyIcm >= 30000)
        {
            Console.WriteLine("You are eligible for the loan");
        }
        else
        {
            Console.WriteLine("You are less in Criteria ");
        }

    }

    public static void CalculateIncomeTax()
    {
        Console.Write("Enter annual income: ");
        double income = Convert.ToDouble(Console.ReadLine());

        double tax = 0;
        if(income <= 250000)
        {
            tax = 0;
        }else if(income <= 500000)
        {
            tax = (income - 250000) * 0.05;
        }else if (income <= 1000000){
            tax = (250000 * 0.05) + (income - 500000) * 0.20;
        }
        else{
            tax = (250000 * 0.05) + (500000 * 0.20) + (income - 1000000) * 0.30;
        }
        Console.WriteLine("Total Tax Payable: ₹" + tax);

    }
    static void EnterTransactions()
    {
        int count = 0;
        double total = 0;

        Console.WriteLine("Enter 5 transactions (negative values will be skipped): ");

        for (int i = 1; i <= 5; i++)
        {
            Console.Write($"Transaction {i}: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount < 0)
            {
                Console.WriteLine("Invalid transaction skipped.");
                continue;
            }

            total += amount;
            count++;
        }

        Console.WriteLine($"Valid Transactions: {count}");
        Console.WriteLine($"Total Amount: ₹{total}");
    }
}