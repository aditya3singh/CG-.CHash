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
            FlightFareUtility utility = new FlightFareUtility();
            Console.WriteLine("=== Airline Flight Fare System ===");

            while (true)
            {
                Console.WriteLine("\n1. Display (Low to High) | 2. Update Fare | 3. Add Ticket | 4. Exit");
                Console.Write("Choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

                try
                {
                    switch (choice)
                    {
                        case 1:
                            var tickets = utility.GetAllTickets();
                            foreach (var t in tickets) Console.WriteLine(t);
                            break;

                        case 2:
                            Console.Write("Enter Ticket ID: ");
                            string id = Console.ReadLine();
                            Console.Write("Enter New Fare: ");
                            int newPrice = int.Parse(Console.ReadLine());
                            utility.UpdateFare(id, newPrice);
                            Console.WriteLine("Fare updated and sorted.");
                            break;

                        case 3:
                            Console.WriteLine("Input Format: TicketID Name Fare");
                            string[] input = Console.ReadLine().Split(' ');
                            utility.AddTicket(new Ticket
                            {
                                Id = input[0],
                                PassengerName = input[1],
                                Fare = int.Parse(input[2])
                            });
                            Console.WriteLine("Ticket registered successfully.");
                            break;

                        case 4:
                            Console.WriteLine("Thank You");
                            return;
                    }
                }
                catch (CustomBaseException ex) { Console.WriteLine($"[Fare Rule] {ex.Message}"); }
                catch (Exception) { Console.WriteLine("[System Error] Invalid input format."); }
            }
        }
    }
}