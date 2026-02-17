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
            SupportUtility utility = new SupportUtility();
            Console.WriteLine("=== IT Support Ticket System ===");

            while (true)
            {
                Console.WriteLine("\n1. Display (by Priority) | 2. Escalate Ticket | 3. Add Ticket | 4. Exit");
                Console.Write("Choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

                try
                {
                    switch (choice)
                    {
                        case 1:
                            foreach (var t in utility.GetAllTickets()) Console.WriteLine(t);
                            break;

                        case 2:
                            Console.Write("Enter Ticket ID to Escalate: ");
                            string id = Console.ReadLine();
                            utility.EscalateTicket(id);
                            Console.WriteLine("Ticket escalated to higher priority.");
                            break;

                        case 3:
                            Console.WriteLine("Input: TicketID Severity(1-5) IssueDescription");
                            string inputLine = Console.ReadLine();
                            string[] parts = inputLine.Split(' ', 3); 

                            utility.AddTicket(new SupportTicket
                            {
                                Id = parts[0],
                                SeverityLevel = int.Parse(parts[1]),
                                IssueDescription = parts[2]
                            });
                            Console.WriteLine("Ticket logged successfully.");
                            break;

                        case 4:
                            Console.WriteLine("Thank You");
                            return;
                    }
                }
                catch (CustomBaseException ex) { Console.WriteLine($"[Support Policy] {ex.Message}"); }
                catch (Exception) { Console.WriteLine("[Error] Input error. Format: ID Severity Description"); }
            }
        }
    }
}