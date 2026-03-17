using System;
using System.Collections.Generic;
using LibrarySystem;
using LibrarySystem.Users;
using LibrarySystem.Interfaces;

using ItemsAlias = LibrarySystem.Items;

class Program
{
    static void Main()
    {
        var book = new ItemsAlias.Book
        {
            Title = "vlc",
            Author = "Aditya Singh",
            ItemID = 101
        };

        var magazine = new ItemsAlias.Magazine
        {
            Title = "TechToday",
            Author = "Gautam Sharma",
            ItemID = 201
        };

        book.DisplayItemDetails();
        Console.WriteLine($"Late Fee for 3 days: {book.CalculateLateFee(3)}\n");

        magazine.DisplayItemDetails();
        Console.WriteLine($"Late Fee for 3 days: {magazine.CalculateLateFee(3)}\n");

        IReservable reservable = book;
        INotifiable notifiable = book;

        reservable.Reserve();
        notifiable.SendNotification("Please return the book on time.\n");

        List<ItemsAlias.LibraryItem> items = new List<ItemsAlias.LibraryItem>
        {
            book,
            magazine
        };

        foreach (var item in items)
        {
            item.DisplayItemDetails();
        }

        Console.WriteLine("\nMethod selection happens at runtime, not the reference type.\n");

        Console.WriteLine("Book and Magazine objects created using namespace alias.");
        Console.WriteLine("1. Nested namespaces organize large projects logically.");
        Console.WriteLine("2. Aliases reduce long namespace references and improve readability.\n");

        LibraryAnalytics.TotalBorrowedItems = 5;
        LibraryAnalytics.DisplayAnalytics();
        Console.WriteLine("Static members store system-wide data shared across all objects.\n");

        Member member = new Member { Role = UserRole.Member };
        ItemStatus status = ItemStatus.Borrowed;

        Console.WriteLine($"User Role: {member.Role}");
        Console.WriteLine($"Item Status: {status}");
        Console.WriteLine("Enums prevent invalid values and improve code readability.\n");

        Console.WriteLine("Admin Alert: System maintenance scheduled.");
        Console.WriteLine("Member Notification: Your borrowed item is due tomorrow.");

        var ebook = new ItemsAlias.eBook
        {
            Title = "Digital C#",
            Author = "Tech Author",
            ItemID = 301
        };

        ebook.Download();
    }
}
