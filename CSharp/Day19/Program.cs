/*
 using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Start reading file...");

        string content = await File.ReadAllTextAsync("data.txt");

        Console.WriteLine("File content: " + content);

        Console.WriteLine("End of the program");
    }

    static async Task<int> GetDataAsync()
    {
        await Task.Delay(100);
        return 42;
    }
} 
 */












/*
 
 using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Thread worker = new Thread(() =>
        {
            Console.WriteLine("Worker thread running");
        });

        worker.Start();

        int data = await GetDataAsync();
        Console.WriteLine("Data: " + data);
    }

    static async Task<int> GetDataAsync()
    {
        await Task.Delay(100);
        return 42;
    }
}

 
 */