using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    public static void Main()

    {
        Console.Write("enter the number of Product: ");
        int Product = Convert.ToInt32(Console.ReadLine());

        int[] prices = new int[Product];
        int sum = 0;
        for(int i= 0; i< Product; i++)
        {
            while (true)
            {
                Console.Write($"enter the price for the product {i+1} :");
                int price = int.Parse(Console.ReadLine());
                if(price > 0)
                {
                    prices[i] = price;
                    sum += price;
                    break;
                }
                Console.WriteLine("Product id must be positive");
            }
        }

        int avg = sum / Product;
        Console.Write($"the average of the product price is {avg}");


    }
}