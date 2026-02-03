
class Program
{
    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n QuickMart Traders ");
            Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
            Console.WriteLine("2. View Last Transaction");
            Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TransactionManager.CreateTransaction();
                    break;

                case "2":
                    TransactionManager.ViewLastTransaction();
                    break;

                case "3":
                    TransactionManager.RecalculateAndPrint();
                    break;

                case "4":
                    Console.WriteLine("\nThank you. Application closed normally.");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please select a valid menu option.");
                    break;
            }
        }
    }
}