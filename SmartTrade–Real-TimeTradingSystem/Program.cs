class Program
{
    static void Main()
    {
        // TASK 1
        PriceSnapshot snapshot = new PriceSnapshot
        {
            StockSymbol = "AAPL",
            Price = 150.50m
        };

        Console.WriteLine($"Stock Symbol: {snapshot.StockSymbol}");
        Console.WriteLine($"Stock Price: {snapshot.Price}");
        Console.WriteLine();

        TradeRepository<Trade> repo = new TradeRepository<Trade>();

        EquityTrade t1 = new EquityTrade
        {
            TradeID = 1,
            Stock = "AAPL",
            Quantity = 100,
            MarketPrice = 150.50m
        };

        EquityTrade t2 = new EquityTrade
        {
            TradeID = 2,
            Stock = "MSFT",
            Quantity = 50,
            MarketPrice = null
        };

        repo.AddTrade(t1);
        repo.AddTrade(t2);

        Console.WriteLine();

        foreach (Trade trade in repo.GetAllTrades())
        {
            TradeProcessor.ProcessTrade(trade);

            decimal tradeValue = trade.CalculateTradeValue();
            decimal brokerage = tradeValue.CalculateBrokerage();
            decimal gst = brokerage.CalculateGST();

            Console.WriteLine($"Trade Value: {tradeValue}");
            Console.WriteLine($"Brokerage: {brokerage}");
            Console.WriteLine($"GST: {gst}");
            Console.WriteLine(trade);
            Console.WriteLine();
        }

        TradeAnalytics.DisplayAnalytics();
        BoxingDemo.ShowBoxingUnboxing();
    }
}
