using System;

delegate void OrderDeligate(string orderId);
delegate void PaymentDelegate(decimal amount);

class NotificationService
{
    public void SendEmail(string id)
    {
        Console.WriteLine("Email" + id);
    }
    public void SendSMS(string msg)
    {
        Console.WriteLine("Sms: " + msg);
    }
}

class PaymentService
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Payment of " + amount + " processed successfully");
    }
}


static class PaymentExtensions
{
    public static bool IsValidPayment(this decimal amount)
    {
        return amount > 0 && amount <= 1_000_000;
    }
}
