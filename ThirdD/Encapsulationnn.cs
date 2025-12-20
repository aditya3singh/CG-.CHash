using System;
class Wallet
{
    private double money;
    public Wallet(double instMoney)
    {
        money = instMoney;
    }

    public void AddMoney(double amt)
    {
        if (amt > 0)
        {
            money += amt;
        }
        else
        {
            Console.WriteLine("Invalid amount");
        }
    }
    public double GetBalance()
    {
        return money;
    }

}