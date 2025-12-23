class InsuranceService
{
    public double CalculateCoverage(string input)
    {
        if (double.TryParse(input, out double coverage))
        {
            return coverage * 0.8;
        }
        else
        {
            Console.WriteLine("Invalid input");
            return 0;
        }
    }
}
