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
            MedicineUtility utility = new MedicineUtility();
            Console.WriteLine("Pharmacy Inventory System");

            while (true)
            {
                Console.WriteLine("\n1. Display All | 2. Update Price | 3. Add Medicine | 4. Exit");
                Console.Write("Choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

                try
                {
                    switch (choice)
                    {
                        case 1:
                            var meds = utility.GetAllMedicines();
                            foreach (var m in meds) Console.WriteLine(m);
                            break;

                        case 2:
                            Console.Write("Enter ID: ");
                            string upId = Console.ReadLine();
                            Console.Write("Enter New Price: ");
                            int price = int.Parse(Console.ReadLine());
                            utility.UpdateMedicinePrice(upId, price);
                            Console.WriteLine("Price updated successfully.");
                            break;

                        case 3:
                            Console.WriteLine("Input: MedicineID Name Price ExpiryYear");
                            string[] input = Console.ReadLine().Split(' ');
                            utility.AddMedicine(new Medicine
                            {
                                Id = input[0],
                                Name = input[1],
                                Price = int.Parse(input[2]),
                                ExpiryYear = int.Parse(input[3])
                            });
                            Console.WriteLine("Medicine added.");
                            break;

                        case 4:
                            Console.WriteLine("Thank You");
                            return;
                    }
                }
                catch (CustomBaseException ex)
                {
                    Console.WriteLine($"[Business Error] {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[System Error] {ex.Message}");
                }
            }
        }
    }
}