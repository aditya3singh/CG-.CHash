using System;
using System.Collections.Generic;

public class Program
{
    public static Stack<Order> OrderStack = new Stack<Order>();

    public static void Main()
    {
        Order obj = new Order();

        int id = int.Parse(Console.ReadLine());
        string name = Console.ReadLine();
        string item = Console.ReadLine();

        obj.AddOrderDetails(id, name, item);

        Console.WriteLine(obj.GetOrderDetails());

        obj.RemoveOrderDetails();

        Console.WriteLine(OrderStack.Count);
    }
}

public class Order
{
    public int OrderId;
    public string CustomerName;
    public string Item;

    public Stack<Order> AddOrderDetails(int id, string name, string item)
    {
        Order order = new Order();
        order.OrderId = id;
        order.CustomerName = name;
        order.Item = item;

        Program.OrderStack.Push(order);
        return Program.OrderStack;
    }

    public string GetOrderDetails()
    {
        Order order = Program.OrderStack.Peek();
        return order.OrderId + " " + order.CustomerName + " " + order.Item;
    }

    public Stack<Order> RemoveOrderDetails()
    {
        Program.OrderStack.Pop();
        return Program.OrderStack;
    }
}
