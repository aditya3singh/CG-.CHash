using System;

namespace LibrarySystem
{
    public partial class LibraryAnalytics
    {
        public static void DisplayAnalytics()
        {
            Console.WriteLine($"Total Items Borrowed: {TotalBorrowedItems}");
        }
    }
}
