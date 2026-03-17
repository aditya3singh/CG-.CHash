

using System.Runtime.CompilerServices;

struct PriceSnapshot
{
    public string Symbol { get; set; }
    public int Price { get; set; }
}

public abstract class Trade
{
    public int TradeId { get; set; }
    public string StockSymbol { get; set; }
    public int Quantity { get; set; }

    public abstract decimal CalculateTradeValue();
    public override string ToString()
    {

        return $"Trade id: {TradeId}";
    }
}

class EquityTrade : Trade
{
    public decimal ? MarketPrice { get; set; }
    public override decimal CalculateTradeValue()
    {
        return (MarketPrice ?? 0) * Quantity;
    }
}

static class TradeAnalytics
{
    static int totalTrade;
    public static void TotalTrade()
    {
        Console.WriteLine($"total trade value: {totalTrade}");
    }
}

class TradeRepository<T> where T : Trade
{
    private readonly List<T> trades = new List<T>();
    public void AddTrade(T trade)
    {
        trades.Add(trade);
        TradeAnalytics.totalTrade++;
        Console.WriteLine("successfull addition");
    }

    public IEnumerable<T> GetAllTrades()
    {
        return trades;
    }
}

public static class FinancialCalculation
{
    public static deciaml CalculateBrokerage(this decimal amount) 
    {
        return amount * 0.001m;
    }
    public static decimal CalculateGST(this decimal amount)
    {
        return amount * 0.18m;
    }
}

public static class TradeProcessor
{
    public static void ProcessTrade(Trade trade)
    {
        switch (trade)
        {
            case EquityTrade:
                Console.WriteLine("Processing Equity Trade");
                break;
            default:
                Console.WriteLine("Unknown Trade Type");
                break;
        }
    }
}


class Program
{
    public static void Main()
    {
        PriceSnapshot snapshot = new PriceSnapshot
        {
            Symbol = "AAPL",
            Price = 150.50m
        };
        Console.WriteLine($"Stock Symbol: {snapshot.Symbol}");
        Console.WriteLine($"Stock Price: {snapshot.Price}");
        Console.WriteLine();

        TradeRepository<Trade> repo = new TradeRepository<Trade>();
        EquityTrade trade1 = new EquityTrade
        {
            TradeId = 1,
            StockSymbol = "NSE",
            Quantity = 100,
            MarketPrice = 150.00m
        };
        EquityTrade trade2 = new EquityTrade
        {
            TradeId = 2,
            Symbol = "MSFT",
            Quantity = 50,
            MarketPrice = null
        };

        repo.AddTrade(trade1);
        repo.AddTrade(trade2);

        foreach (var trade in repository.GetAllTrades())
        {
            TradeProcessor.ProcessTrade(trade);

            decimal tradeValue = trade.CalculateTradeValue();
            decimal brokerage = tradeValue.CalculateBrokerage();
            decimal gst = brokerage.CalculateGST();
        }
    }
}