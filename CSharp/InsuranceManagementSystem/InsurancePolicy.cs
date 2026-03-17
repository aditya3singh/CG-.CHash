abstract class InsurancePolicy
{
    public int PolicyNumber { get; init; }

    private double premium;
    public double Premium
    {
        get { return premium; }
        set
        {
            if (value > 0)
                premium = value;
        }
    }

    public string PolicyHolder { get; set; }

    public virtual double CalculatePremium()
    {
        return Premium;
    }

    public void ShowPolicy()
    {
        Console.WriteLine("Insurance Policy");
    }
}
