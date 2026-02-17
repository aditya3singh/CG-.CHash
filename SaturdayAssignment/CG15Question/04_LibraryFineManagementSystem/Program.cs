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
            LibraryUtility library = new LibraryUtility();
            Console.WriteLine("=== Library Fine Management System ===");

            while (true)
            {
                Console.WriteLine("\n1. Display Fines | 2. Pay Fine | 3. Add Member | 4. Exit");
                Console.Write("Choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

                try
                {
                    switch (choice)
                    {
                        case 1:
                            foreach (var m in library.GetMembersSortedByFine()) Console.WriteLine(m);
                            break;

                        case 2:
                            Console.Write("Member ID: ");
                            string id = Console.ReadLine();
                            Console.Write("Payment Amount: ");
                            int amount = int.Parse(Console.ReadLine());
                            library.PayFine(id, amount);
                            Console.WriteLine("Fine payment processed.");
                            break;

                        case 3:
                            Console.WriteLine("Input: MemberId Name FineAmount");
                            string[] input = Console.ReadLine().Split(' ');
                            library.AddMember(new Member
                            {
                                Id = input[0],
                                Name = input[1],
                                FineAmount = int.Parse(input[2])
                            });
                            Console.WriteLine("Member registered.");
                            break;

                        case 4:
                            Console.WriteLine("Thank You");
                            return;
                    }
                }
                catch (CustomBaseException ex) { Console.WriteLine($"[Library Policy] {ex.Message}"); }
                catch (Exception) { Console.WriteLine("[Error] Input format was incorrect."); }
            }
        }
    }
}