class Program
{
    static void Main()
    {
        Patient p = new Patient(1, "Aditya", 22);
        p.SetMedicalHistory("Diabetes");

        Doctor d = new Doctor("Dr. Sharma", "Cardiology", "LIC123");

        DiagnosisService ds = new DiagnosisService();

        int age = p.Age;
        string condition = "";

        ds.Evaluate(in age, ref condition, out string risk, 70, 80);

        Console.WriteLine($"Condition: {condition}, Risk: {risk}");

        var bill = new BillingService
        {
            ConsultationFee = 500,
            TestCharges = 1000,
            RoomCharges = 2000
        };

        Console.WriteLine($"Total Bill: {bill.CalculateTotal()}");

        Cardiologist c = new Cardiologist("Dr. Mehta", "Cardiology", "LIC456");
        c.PrintDetails();
    }
}
