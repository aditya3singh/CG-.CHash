using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Security security = new Security();
        security.Authenticate();

        InsurancePolicy life = new LifeInsurance
        {
            PolicyNumber = 101,
            PolicyHolder = "Amit",
            Premium = 5000
        };

        PolicyDirectory directory = new PolicyDirectory();
        directory.AddPolicy(life);
        directory.AddPolicy(health);

        Console.WriteLine("Life Premium: " + life.CalculatePremium());
        Console.WriteLine("Health Premium: " + health.CalculatePremium());

        LifeInsurance li = new LifeInsurance
        {
            PolicyHolder = "Test",
            Premium = 1000
        };

        InsurancePolicy baseRef = li;

        li.ShowPolicy();        
        baseRef.ShowPolicy();
    }
}
