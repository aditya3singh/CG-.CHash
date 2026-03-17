using System;
using LibrarySystem.Interfaces;
namespace LibrarySystem.Items
{
    public class Book : LibraryItem, IReservable, INotifiable
    {
        public override void DisplayItemDetails()
        {
            Console.WriteLine("Item Type: Book");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Item ID: {ItemID}");
        }
        public override double CalculateLateFee(int days)
        {
            return days * 1.0;
        }
        void IReservable.Reserve()
        {
            Console.WriteLine("Book reserved successfully.");
        }
        void INotifiable.SendNotification(string message)
        {
            Console.WriteLine($"Notification: {message}");
        }
    }
}
