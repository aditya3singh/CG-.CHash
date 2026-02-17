using System;
using System.Collections.Generic;
using System.Linq;

namespace TechNova.InventorySystem
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }

        public override string ToString() => $"[{SKU}] {Name} - ${Price:N2}";
    }


    public class Electronics : Product
    {
        public string Brand { get; set; }
        public int WarrantyMonths { get; set; }
        public int PowerWatts { get; set; }
        public string Specifications { get; set; } // e.g., "16GB RAM, 512GB SSD"
    }

    public class Grocery : Product
    {
        public DateTime ExpiryDate { get; set; }
        public double WeightKg { get; set; }
        public bool IsOrganic { get; set; }
        public bool IsExpired => DateTime.Now > ExpiryDate;
    }

    public class Clothing : Product
    {
        public string Size { get; set; } // S, M, L, XL
        public string Fabric { get; set; }
        public string Color { get; set; }
    }

    public class InventoryManager<T> where T : Product
    {
        private readonly List<T> _items = new List<T>();

        public void AddItem(T item)
        {
            if (_items.Any(p => p.SKU == item.SKU))
            {
                Console.WriteLine($"[Error] SKU {item.SKU} already exists in {typeof(T).Name} inventory!");
                return;
            }

            if (item.Price < 0)
            {
                Console.WriteLine($"[Error] Price for {item.Name} cannot be negative.");
                return;
            }

            _items.Add(item);
            Console.WriteLine($"[System] Registered {item.Name} ({item.SKU}) successfully.");
        }

        public IEnumerable<T> GetActiveInventory() => _items;

        public void PrintReport()
        {
            Console.WriteLine($"\n--- {typeof(T).Name.ToUpper()} STOCK REPORT ");
            if (!_items.Any()) Console.WriteLine("No items currently in stock.");

            foreach (var item in _items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== TechNova Retail Management v1.0 ===\n");

            var techDept = new InventoryManager<Electronics>();
            var foodDept = new InventoryManager<Grocery>();

            var laptop = new Electronics
            {
                Id = 101,
                SKU = "TECH-MBP-14",
                Name = "MacBook Pro 14\"",
                Brand = "Apple",
                WarrantyMonths = 12,
                Price = 1999.99m
            };
            techDept.AddItem(laptop);

            foodDept.AddItem(new Grocery
            {
                Id = 501,
                SKU = "GROC-MILK-01",
                Name = "Whole Milk (1L)",
                WeightKg = 1.0,
                Price = 3.50m,
                ExpiryDate = DateTime.Now.AddDays(5)
            });

            techDept.AddItem(new Electronics { SKU = "TECH-MBP-14", Name = "Fake Laptop" });

            techDept.PrintReport();
            foodDept.PrintReport();


            Console.WriteLine("\nSession finished. Press any key to exit.");
            Console.ReadKey();
        }
    }
}