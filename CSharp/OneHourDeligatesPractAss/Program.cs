using System;

public namespace EcommerceAssignmet
{
    public class Repository<T>
    {
        private List<T> items = new List<T>;

        public void Add(T item)
        {
            items.Add(item);
        }
        public List<T> void GetALl()
        {
            return items;
        }
    }
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public double Amount { get; set; }

        public override string ToString()
        {
            return $"OrderId: {OrderId}, Customer: {CustomerName}, Amount: {Amount}";
        }
    }
    public delegate void OrderCallback(string mag);

    public class OrderProcessor
    {
        public event Action<string> OrderProcessor();

        public void ProcessOrder
            (
                Order order, 
                Func<double, double> taxCalculator,
                Func<double, double> discountCalculator,
                Predicate<Order> validator,
                OrderCallback callback
            )
        {
            if (!validator)
            {
                callback($"Order validation failed.");
                return;
            }
            double tax = taxCalculator(order.Amount);
            double discount = discountCalculator(order.Amount);

            order.Amount = order.Amount + tax - discount;
            callback($"this is the order amount after the discount: {order.Amount}");

            OrderProcessor?.Invoke($"Event: Order {order.OrderId} completed.");
        }

    }
    class Program
    {
        public static void Main()
        {
            Repository<Order> repository = new Repository<Order>();
            repository.Add(new Order { OrderId = 1, CustomerName = "Alice", Amount = 5000 });
            repository.Add(new Order { OrderId = 2, CustomerName = "blice", Amount = 2000 });
            repository.Add(new Order { OrderId = 3, CustomerName = "clice", Amount = 8000 });

            Func<double, double> taxCalculator = amount => amount * 0.18;
            Func<double, double> discountCalculator = amount => amount * 0.05;
            Predicate<Order> validator = order=> order.Amount >= 3000;
            OrderCallback callback = massage => Console.WriteLine($"this is the massage: {massage}");

            Action<string> logger => Console.WriteLine($"this is the logger call{logger}");
            Action<string> notifier => Console.WriteLine($"this is the notifier: {notifier}");

            OrderProcessor ordpro = new OrderProcessor();
            ordpro.OrderProcessor += logger;
            ordpro.OrderProcessor += notifier;

            foreach(var order in repository.GetAll())
            {
                ordpro.ProcessOrder
                    (
                    order,
                    taxCalculator,
                    discountCalculator,
                    validator,
                    callback

                    );
                Console.WriteLine();
            }
            List<Order> processedOrder = repository.GetAll();
            processedOrder.Sort((o1, o2) => o2.Amount.CompareTo(o1.Amount));
            Console.WriteLine("this is successfully comp.")'\;'

            foreach (var order in processedOrder)
            {
                Console.WriteLine(order);
            }

        }
    }

}