using System;

class RobotSafetyException : Exception
{
    public RobotSafetyException(string message) : base(message) { }
}

class FactoryRobotHazardAnalyzer
{
    public double CalculateHazardRisk()
    {
        Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
        double armPrecision = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter Worker Density (1 - 20):");
        int workerDensity = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
        string machineryState = Console.ReadLine();
        double machineRiskFactor;

        try
        {
            if (armPrecision < 0.0 || armPrecision > 1.0)
                throw new RobotSafetyException("Error: Arm precision must be 0.0–1.0");

            if (workerDensity < 1 || workerDensity > 20)
                throw new RobotSafetyException("Error: Worker density must be 1–20");

            if (machineryState != "Worn" &&
                machineryState != "Faulty" &&
                machineryState != "Critical")
                throw new RobotSafetyException("Error: Unsupported machinery state");
        }
        catch (RobotSafetyException e)
        {
            Console.WriteLine(e.Message);
            return 0;
        }

        if (machineryState == "Worn")
        {
            machineRiskFactor = 1.3;
        }
        else if (machineryState == "Faulty")
        {
            machineRiskFactor = 2.0;
        }
        else
        {
            machineRiskFactor = 3.0;
        }
        return ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);
    }

    public static void Main(string[] args)
    {
        FactoryRobotHazardAnalyzer obj = new FactoryRobotHazardAnalyzer();
        obj.CalculateHazardRisk();
    }
}