using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static List<dynamic> books = new List<dynamic>();
    static int bookIdCounter = 1;

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1.Add Book");
            Console.WriteLine("2.Update Book");
            Console.WriteLine("3.Delete Book");
            Console.WriteLine("4.View All Books");
            Console.WriteLine("5.Search Book by Name");
            Console.WriteLine("6.Search Book by Publisher");
            Console.WriteLine("7.View Highest Price Book");
            Console.WriteLine("8.View Lowest Price Book");
            Console.WriteLine("9.Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddBook();
                    break;
                case 2:
                    UpdateBook();
                    break;
                case 3:
                    DeleteBook();
                    break;
                case 4:
                    ViewBooks();
                    break;
                case 5:
                    SearchByName();
                    break;
                case 6:
                    SearchByPublisher();
                    break;
                case 7:
                    HighestPriceBook();
                    break;
                case 8:
                    LowestPriceBook();
                    break;
                case 9:
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    static void AddBook()
    {
        Console.Write("Enter Book Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Publisher: ");
        string publisher = Console.ReadLine();

        Console.Write("Enter Price: ");
        double price = double.Parse(Console.ReadLine());

        dynamic book = new
        {
            BookId = bookIdCounter++,
            Name = name,
            Publisher = publisher,
            Price = price
        };

        books.Add(book);
        Console.WriteLine("Book added successfully");
    }

    static void UpdateBook()
    {
        Console.Write("Enter Book ID to update: ");
        int id = int.Parse(Console.ReadLine());

        var book = books.FirstOrDefault(b => b.BookId == id);

        if (book == null)
        {
            Console.WriteLine("Book not found");
            return;
        }

        Console.Write("Enter New Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter New Publisher: ");
        string publisher = Console.ReadLine();

        Console.Write("Enter New Price: ");
        double price = double.Parse(Console.ReadLine());

        books.Remove(book);
        books.Add(new { BookId = id, Name = name, Publisher = publisher, Price = price });

        Console.WriteLine("Book updated successfully");
    }

    static void DeleteBook()
    {
        Console.Write("Enter Book ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        var book = books.FirstOrDefault(b => b.BookId == id);

        if (book == null)
        {
            Console.WriteLine("Book not found");
            return;
        }

        books.Remove(book);
        Console.WriteLine("Book deleted successfully");
    }

    static void ViewBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available");
            return;
        }

        foreach (var book in books)
        {
            DisplayBook(book);
        }
    }

    static void SearchByName()
    {
        Console.Write("Enter Book Name: ");
        string name = Console.ReadLine();

        var result = books.Where(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        foreach (var book in result)
            DisplayBook(book);
    }

    static void SearchByPublisher()
    {
        Console.Write("Enter Publisher Name: ");
        string publisher = Console.ReadLine();

        var result = books.Where(b => b.Publisher.Equals(publisher, StringComparison.OrdinalIgnoreCase));

        foreach (var book in result)
            DisplayBook(book);
    }

    static void HighestPriceBook()
    {
        if (books.Count == 0) return;

        var book = books.OrderByDescending(b => b.Price).First();
        DisplayBook(book);
    }

    static void LowestPriceBook()
    {
        if (books.Count == 0) return;

        var book = books.OrderBy(b => b.Price).First();
        DisplayBook(book);
    }

    static void DisplayBook(dynamic book)
    {
        Console.WriteLine($"ID: {book.BookId}, Name: {book.Name}, Publisher: {book.Publisher}, Price: {book.Price}");
    }
}
