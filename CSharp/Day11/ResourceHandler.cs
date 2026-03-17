using System;

class ResourceHandler : IDisposable
{
    public ResourceHandler()
    {
        Console.WriteLine("Resource acquired");

    }
    public void Dispose()
    {
        Console.WriteLine("Resource released");
    }
}