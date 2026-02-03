using System;
using System.Collections.Generic;

class Bike
{
    public string Model { get; set; }
    public int PricePerDay { get; set; }
    public string Brand { get; set; }
}

class BikeUtility
{
    public void AddBikeDetails(string model, string brand, int pricePerDay)
    {
        int key = Program.bikeDetails.Count + 1;
        Bike bike = new Bike
        {
            Model = model,
            PricePerDay = pricePerDay,
            Brand = brand
        };
        Program.bikeDetails.Add(key, bike);
        Console.WriteLine("\nBike details added successfully\n");
    }
    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string, List<Bike>> grouped = new SortedDictionary<string, List<Bike>>();
        foreach (KeyValuePair<int, Bike> item in Program.bikeDetails)
        {
            Bike bike = item.Value;
            if (!grouped.ContainsKey(bike.Brand))
            {
                grouped[bike.Brand] = new List<Bike>();
            }
            grouped[bike.Brand].Add(bike);
        }
        return grouped
    }
}

    class Program
{

}