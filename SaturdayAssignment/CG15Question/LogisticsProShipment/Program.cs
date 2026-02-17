using System;

class Shipment
{
    public string ShipmentCode{get; set;}
    public string TransportMode{get; set;}
    public double Weight{get; set;}
    public int StorageDays{get; set;}
}

class ShipmentDetails : Shipment
{
    public bool ValidateShipmentCode()
    {
        if(string.IsNullOrEmpty(ShipmentCode) || ShipmentCode.Length != 7)
        {
            return false;
        }
        if(!ShipmentCode.StartsWith("GC#")) return false;

        string numericPart = ShipmentCode.Substring(3);
        return long.TryParse(numericPart, out _);   
    }
       public double CalculateTotalCost()
    {
        double ratePerKg = 0.0;
        switch (TransportMode)
        {
            case "Sea":
                ratePerKg = 15.00;
                break;
            case "Air":
                ratePerKg = 50.00;
                break;
            case "Land":
                ratePerKg = 25.00;
                break;
            default:
                return 0.0;
        }

        double totalCost = (Weight * ratePerKg) + Math.Sqrt(StorageDays);

        return Math.Round(totalCost, 2);

    }

}

class Program
{
    static void Main(string[] args)
    {
        ShipmentDetails shipment = new ShipmentDetails();

        Console.Write("Enter Shipment Code: ");
        shipment.ShipmentCode = Console.ReadLine();

        bool isValid = shipment.ValidateShipmentCode();

        if (!isValid)
        {
            Console.WriteLine("Invalid shipment code");
            return;
        }

        Console.Write("Enter Transport Mode (Sea/Air/Land): ");
        shipment.TransportMode = Console.ReadLine();

        Console.Write("Enter Weight: ");
        shipment.Weight = double.Parse(Console.ReadLine());

        Console.Write("Enter Storage Days: ");
        shipment.StorageDays = int.Parse(Console.ReadLine());

        double finalCost = shipment.CalculateTotalCost();

        Console.WriteLine($"The total shipping cost is {finalCost:F2}");
    }
}