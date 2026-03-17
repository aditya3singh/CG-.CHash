
//delegate void ErrorDelegate(string msg);
//class Program
//{

//    static void Main()
//    {
//        //PaymentService service = new PaymentService();

//        //PaymentDelegate payment = service.ProcessPayment; // method reference

//        //decimal amount = 5000;

//        //if (amount.IsValidPayment())
//        //{
//        //    payment(amount); // 🔁 callback happens here
//        //}
//        //else
//        //{
//        //    Console.WriteLine("Invalid payment");
//        //}

//        //NotificationService service = new NotificationService();

//        //OrderDelegate notify = null;
//        //notify += service.SendEmail;
//        //notify += service.SendSMS;

//        //notify("ORD1001");

//        //Action<string> logActivity = message => Console.WriteLine("Log Entry: " + message);
//        //logActivity("User logged in at 10:30 AM");

//        //    Func<decimal, decimal, decimal> calculateDiscount = (price, discoutn) => price - (price * discoutn / 100);
//        //    Console.WriteLine(calculateDiscount(1000, 10));
//        //
//        //Predicate<int> isEligible = age => age >= 18;
//        //Console.WriteLine(isEligible(20));

//        //ErrorDelegate errorHandler = delegate (string msg)
//        //{
//        //    Console.WriteLine("Error: " + msg);
//        //};
//        //errorHandler("File not found");

//        Button btn = new Button();
//        btn.Clicked += () => Console.WriteLine("Button was clicked");
//        btn.Click();



//    }
//}
/*

using System;

// 1️⃣ Custom delegate
delegate void ErrorDelegate(string msg);
delegate void SecurityAction(string location);

// 2️⃣ Program
class Program
{
    static void Main()
    {
        // ---------- BUTTON EVENT DEMO ----------
        Button btn = new Button();
        btn.Clicked += () => Console.WriteLine("Button was clicked");
        btn.Click();

        Console.WriteLine();

        // ---------- SECURITY SYSTEM DEMO ----------

        // Object initialization
        MotionSensor livingRoomSensor = new MotionSensor();
        AlarmSystem siren = new AlarmSystem();
        PoliceNotifier police = new PoliceNotifier();

        // Multicast delegate
        SecurityAction panicSequence = siren.SoundSiren;
        panicSequence += police.CallDispatch;

        // Linking delegate to sensor
        livingRoomSensor.OnEmergency = panicSequence;

        // Simulation
        livingRoomSensor.DetectIntruder("Main Lobby");
    }
}
*/


using System;
using System.Collections.Generic;

namespace EcommerceAssessment
{
    public class Repository<T>
    {
        private List<T> items = new List<T>();
        public void Add(T item)
        {
            items.Add(item);
        }
        public List<T> GetAll()
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

    public delegate void OrderCallback(string message);

    public class OrderProcessor
    {
        public event Action<string> OrderProcessed;

        public void ProcessOrder(
            Order order,
            Func<double, double> taxCalc,
            Func<double, double> discountCalc,
            Predicate<Order> check,
            OrderCallback callback)
        {
            if (!check(order))
            {
                callback("Order validation failed.");
                return;
            }

            double tax = taxCalc(order.Amount);
            double discount = discountCalc(order.Amount);

            order.Amount = order.Amount + tax - discount;

            callback($"Order {order.OrderId} processed successfully.");
            OrderProcessed?.Invoke($"Event: Order {order.OrderId} completed.");
        }
    }

    class Program
    {
        static void Main()
        {
            Repository<Order> repo = new Repository<Order>();
                 
            repo.Add(new Order { OrderId = 1, CustomerName = "Alice", Amount = 5000 });
            repo.Add(new Order { OrderId = 2, CustomerName = "Bob", Amount = 2000 });
            repo.Add(new Order { OrderId = 3, CustomerName = "Charlie", Amount = 8000 });

            Func<double, double> tax = a => a * 0.18;
            Func<double, double> discount = a => a * 0.05;
            Predicate<Order> valid = o => o.Amount >= 3000;

            OrderCallback cb = msg => Console.WriteLine("Callback: " + msg);

            Action<string> logger = msg => Console.WriteLine("Logger: " + msg);
            Action<string> notifier = msg => Console.WriteLine("Notifier: " + msg);

            OrderProcessor p = new OrderProcessor();
            p.OrderProcessed += logger;
            p.OrderProcessed += notifier;

            foreach (var o in repo.GetAll())
            {
                p.ProcessOrder(o, tax, discount, valid, cb);
                Console.WriteLine();
            }

            List<Order> list = repo.GetAll();
            list.Sort((a, b) => b.Amount.CompareTo(a.Amount));

            Console.WriteLine("Sorted Orders (Descending Amount):");
            foreach (var o in list)
            {
                Console.WriteLine(o);
            }
        }
    }
}