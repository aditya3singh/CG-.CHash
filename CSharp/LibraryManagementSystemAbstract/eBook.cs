using System;

namespace LibrarySystem.Items
{
    public class eBook : LibraryItem
    {
        public override void DisplayItemDetails()
        {
            Console.WriteLine("Item Type: eBook");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Item ID: {ItemID}");
        }

        public override double CalculateLateFee(int days)
        {
            return days * 0.2;
        }

        public void Download()
        {
            Console.WriteLine("eBook downloaded successfully.");
        }
    }
}
