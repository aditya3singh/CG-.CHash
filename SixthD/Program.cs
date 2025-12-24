// class Program
// {
//     static void Main()
//     {
//         /*
//         StockPrice stockPrice = new StockPrice();
//         stockPrice.Symbol = "AAPL";
//         stockPrice.Price = 150.25m;

//         Trade trade1 = new Trade();
//         trade1.symbol = "AAPL";
//         trade1.quantity = 100;
//         trade1.tradeID = 1;

//         Trade trade2 = trade1;
//         trade2.symbol = "MSFT";
//         trade2.quantity = 50;
//         trade2.tradeID = 2;

//         Console.WriteLine($"Stock Symbol: {stockPrice.Symbol}, Price: {stockPrice.Price}");
//         Console.WriteLine($"Trade ID: {trade1.tradeID}, Symbol: {trade1.symbol}, Quantity: {trade1.quantity}");
//         Console.WriteLine($"Trade ID: {trade2.tradeID}, Symbol: {trade2.symbol}, Quantity: {trade2.quantity}");
//         */

//         // Portfolio p1 = new Portfolio { Name = "Growth" };
//         // Portfolio p2 = new Portfolio { Name = "Growth" };

//         // Console.WriteLine(p1.Equals(p2));//False
//         // Console.WriteLine(p1 == p2);

//         // Console.WriteLine(p1.GetHashCode());
//         // Console.WriteLine(p2.GetHashCode());



//         Trade t = new EquityTrade();
//         Console.WriteLine(t.GetType());

//     }
// }

// class EquityTrade : Trade
// {
// }

// class Program
// {
//     static void Main()
//     {
//         Trade t = new EquityTrade();
//         Console.WriteLine(t.GetType());
//     }
// }

/*
class Program
{
    static void Main()
    {
        Repository<Customer> obj = new Repository<Customer>();
        obj.Data = new Customer{ Name = "Aditya" };
        Console.WriteLine(obj.Data.Name);


    }
}
*/

using System.Globalization;

class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();
        int result = calc.Calculatr(5, 10);
        Console.WriteLine(result);
    }
}