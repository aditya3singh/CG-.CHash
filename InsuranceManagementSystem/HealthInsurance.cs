class HealthInsurance : InsurancePolicy
{
    public sealed override double CalculatePremium()
    {
        return Premium + 2000;
    }
}
