using System;

namespace BookStoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO:
            // 1. Read initial input
            // Format: BookID Title Price Stock
            System.Console.WriteLine("Enter the book data spreaded with space");
            string input = System.Console.ReadLine();
            string[] words = input.Split(' ');

            Book book = new Book();
            book.Id = words[0];
            book.Title = words[1];
            book.Price = int.Parse(words[2]);
            book.Stock = int.Parse(words[3]);

            BookUtility utility = new BookUtility(book);

            while (true)
            {
                // TODO:
                // Display menu:
                // 1 -> Display book details
                // 2 -> Update book price
                // 3 -> Update book stock
                // 4 -> Exit
                
                Console.WriteLine("1. Display book details\n2. Update book price\n3. Update book stock\n4. Exit");  
                int choice = 0; // TODO: Read user choice
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        utility.GetBookDetails();
                        break;

                    case 2:
                        // TODO:
                        // Read new price
                        // Call UpdateBookPrice()
                        System.Console.WriteLine("Enter the new price");
                        int price = int.Parse(Console.ReadLine());
                        utility.UpdateBookPrice(price);
                        break;

                    case 3:
                        // TODO:
                        // Read new stock
                        // Call UpdateBookStock()
                        System.Console.WriteLine("Enter the new stock");
                        int stock = int.Parse(Console.ReadLine());
                        utility.UpdateBookStock(stock);
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        // TODO: Handle invalid choice
                        System.Console.WriteLine("Invalid Selection");
                        break;
                }
            }
        }
    }
}
