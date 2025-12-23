class Program
{
    static void Main()
    {
        FileLogger fl = new FileLogger();

        ILogger logger = fl;
        logger.Log();

        INotifier notifier = fl;
        notifier.Log();

        Console.WriteLine("Program executed successfully.");
    }
}

