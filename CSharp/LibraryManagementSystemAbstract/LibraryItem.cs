namespace LibrarySystem.Items
{
    public abstract class LibraryItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int ItemID { get; set; }

        public abstract void DisplayItemDetails();
        public abstract double CalculateLateFee(int days);
    }
}
