using System;
using System.Collections.Generic;
using System.Configuration;



class Program
{
    static void Main()
    {
        Console.WriteLine("enter the number of products: ");
        int qnt = int.Parse(Console.ReadLine());
        int[] price = new int[qnt];
        Console.WriteLine("Array is created dynamically");
        int sum = 0;
        for(int i = 0; i< qnt; i++)
        {
            int value;
            do
            {
                Console.WriteLine($"Enter the positive prices for the product{i}");
                value = int.Parse(Console.ReadLine());


            } while (value <= 0);
            price[i] = value;
            sum += value; 
        }

        double average = (double)sum / qnt;
        Console.WriteLine("Average Price: " + average);

        Array.Sort(price);

        for(int i = 0; i< qnt; i++)
        {
            if (price[i] < average)
            {
                price[i] = 0;
            }
        }
        Console.WriteLine("Prices below average are clearly marked as 0");
        int old = price.Length;
        Array.Resize(ref price, old + 5);
        Console.WriteLine("Array resize works correctly");
        for(int i= old; i< old + 5; i++)
        {
            price[i] = (int)average;
        }

        for (int i = 0; i < price.Length; i++)
        {
            Console.WriteLine($"Index {i} : {price[i]}");
        }


        //----------------task 2 ------------------------------

        int branch = int.Parse(Console.ReadLine());
        int months = int.Parse(Console.ReadLine());

        int[,] SalesData = new int[branch, months];
        int highestSales = 0;

        decimal totalSales = 0.00;

        for(int i= 0; i< branch; i++)
        {
            for(int j = 0; i< months; j++)
            {
                Console.WriteLine($"Enter the sales form branch{i} and month{j}");
                SalesData[i, j] = int.Parse(Console.ReadLine());
                if (SalesData[i, j] > highestSales)
                {
                    highestSales = SalesData[i, j];
                }
            }
        }

        Console.WriteLine($"The globle highest total is {highestSales}");

        for(int i = 0; i< branch; i++)
        {
            int total = 0;
            for(int j = 0; i< months; i++)
            {
                total += SalesData[i, j];
                Console.WriteLine($"the branch wise total is the {total}");
            }
        }
        //----------------task 3 ------------------------------

        int[][] jaggedArray = new int[branch][];

        for(int i= 0; i< branch; i++)
        {
            int cnt = 0;
            for(int j= 0; j < months; j++)
            {
                if (SalesData[i, j] >= average)
                {
                    cnt++;
                }
            }
            jaggedArray[i] = new int[cnt];
            int index = 0;
            for(int j = 0; j < months; j++)
            {
                if (SalesData[i, j] >= average)
                {
                    jaggedArray[i, index] = SalesData[i, j];
                    index++;
                }
            }

        }
        for(int i= 0; i< jaggedSales.Length; i++)
        {
            Console.WriteLine($"Branch wise: {i}");
            if (jaggedArray[i].Length == 0)
            {
                Console.WriteLine("No qualifying sales");
            }
            else
            {
                for(int j = 0; j < jaggedArray.Length; j++)
                {
                    Console.WriteLine(jaggedArray[i][j]);
                }
            }
            Console.WriteLine();
        }

        //--------------------4---------

        Console.WriteLine("Enter the number of Transaction: ");
        int NoFTransaction = int.Parse(Console.ReadLine());

        List<int> custId = new List<int>();
        for(int i = 0; i< NoFTransaction; i++)
        {
            Console.WriteLine($"Enter the customer Id {i + 1}");
            custId.Add(int.Parse(Console.ReadLine()));
        }

        int originalCount = custId.Count;

        HashSet<int> remDup = new HashSet<int>(custId);
        List<int> clinedlist = new List<int>(remDup);

        int clinedCount = clinedlist.Count;
        int diffDup = originalCount - clinedCount;
        Console.WriteLine("\n here is the counted list: ");
        foreach(int cntl in clinedlist)
        {
            Console.WriteLine(cntl);
        }
        Console.WriteLine(diffDup);
    }
}