interface IPrintable
{
    void Print();
    void Scan();
}

class Report : IPrintable
{
    public void Print()
    {
        Console.WriteLine("Printing report");
    }
}