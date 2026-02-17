using System;
using Domain;
using Services;
using Exceptions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankUtility bank = new BankUtility();
            Console.WriteLine("=== Bank Balance Monitoring System ===");

            while (true)
            {
                Console.WriteLine("\n1. Display | 2. Deposit | 3. Withdraw | 4. Add Account | 5. Exit");
                Console.Write("Action: ");

                if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

                try
                {
                    switch (choice)
                    {
                        case 1:
                            foreach (var acc in bank.GetAllAccounts()) Console.WriteLine(acc);
                            break;

                        case 2: // Deposit
                        case 3: // Withdraw
                            Console.Write("Account Number: ");
                            string id = Console.ReadLine();
                            Console.Write("Amount: ");
                            decimal amount = decimal.Parse(Console.ReadLine());
                            bank.ProcessTransaction(id, amount, isDeposit: choice == 2);
                            Console.WriteLine("Transaction Successful.");
                            break;

                        case 4:
                            Console.WriteLine("Input: AccountNumber Name InitialBalance");
                            string[] input = Console.ReadLine().Split(' ');
                            bank.AddAccount(new Account
                            {
                                Id = input[0],
                                HolderName = input[1],
                                Balance = decimal.Parse(input[2])
                            });
                            Console.WriteLine("Account Created.");
                            break;

                        case 5:
                            Console.WriteLine("Thank You");
                            return;
                    }
                }
                catch (CustomBaseException ex) { Console.WriteLine($"[Bank Error] {ex.Message}"); }
                catch (Exception) { Console.WriteLine("[Error] Invalid Input."); }
            }
        }
    }
}