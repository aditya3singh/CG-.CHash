using System;
using System.Text;

class Program
{
    static void Main()
    {
        
        Console.OutputEncoding = Encoding.UTF8;

        var reception = new ReceptionService();
        var record = new RecordService();
        var weighing = new WeighingService();
        var valuation = new ValuationService();

        reception.ItemReceived += record.LogEntry;
        reception.ItemReceived += weighing.WeighItem;
        weighing.ItemWeighed += valuation.FixPrice;

        Console.Clear();
        reception.ReceiveItem("Gold Chain");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}

public class ValuationService
{
    public void FixPrice(string itemName, double weight)
    {
        double rate = 7150.00;
        Console.WriteLine($"Quote: ₹{weight * rate:N2} (Based on {weight}g at ₹{rate}/g)");
    }
}

public class WeighingService
{
    public event Action<string, double> ItemWeighed;

    public void WeighItem(string itemName)
    {
        Console.Write($"Enter weight for {itemName} (in grams): ");
        if (double.TryParse(Console.ReadLine(), out double weight))
        {
            ItemWeighed?.Invoke(itemName, weight);
        }
        else
        {
            Console.WriteLine("Invalid input. Cancelled.");
        }
    }
}

public class RecordService
{
    public void LogEntry(string itemName)
    {
        Console.WriteLine($"Items: {itemName}");
    }
}

public class ReceptionService
{
    public event Action<string> ItemReceived;

    public void ReceiveItem(string itemName)
    {
        
        ItemReceived?.Invoke(itemName);
    }
}