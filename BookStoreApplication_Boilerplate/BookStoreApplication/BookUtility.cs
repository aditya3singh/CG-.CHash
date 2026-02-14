using System;

namespace BookStoreApplication
{
    public class BookUtility
    {
        private Book _book;

        public BookUtility(Book book)
        {
            // TODO: Assign book object
            _book = book;            
        }

        public void GetBookDetails()
        {
            // TODO:
            // Print format:
            // Details: <BookId> <Title> <Price> <Stock>
            System.Console.WriteLine($"{_book.Id} {_book.Title} {_book.Price} {_book.Stock}");
        }

        public void UpdateBookPrice(int newPrice)
        {
            // TODO:
            // Validate new price
            // Update price
            // Print: Updated Price: <newPrice>
            if(newPrice < 0)
            {
                System.Console.WriteLine("Please write price which is positive or greater then zero");
            }
            else
            {
                _book.Price = newPrice;
            }

            System.Console.WriteLine($"this is the updated price {_book.Price}");
        }

        public void UpdateBookStock(int newStock)
        {
            // TODO:
            // Validate new stock
            // Update stock
            // Print: Updated Stock: <newStock>
            if(newStock > 0)
            {
                _book.Stock = newStock;
            }
            else
            {
                System.Console.WriteLine("Please write Stock which is positive or greater then zero");
            }
            System.Console.WriteLine($"this is the updated Stock {_book.Stock}");
        }
    }
}
