using System;

namespace HealthSyncBilling
{
    public abstract class Consultant
    {
        public string ConsultantId { get; set; }
        public string Name { get; set; }

        public abstract double CalculateGrossPayout();

        public virtual double CalculateTax(double grossPayout)
        {
            if (grossPayout <= 5000)
                return 0.05; 
            else
                return 0.15; 
        }

        public bool ValidateConsultantId()
        {
            if (string.IsNullOrEmpty(ConsultantId) || ConsultantId.Length != 6)
                return false;

            if (!ConsultantId.StartsWith("DR"))
                return false;

            string numericPart = ConsultantId.Substring(2);
            return int.TryParse(numericPart, out _);
        }
    }

    public class InHouseConsultant : Consultant
    {
        public double MonthlyStipend { get; set; }
        
        private const double TravelAllowance = 2000;
        private const double PerformanceBonus = 1000;

        public override double CalculateGrossPayout()
        {
            return MonthlyStipend + TravelAllowance + PerformanceBonus;
        }

    }

    public class VisitingConsultant : Consultant
    {
        public int ConsultationsCount { get; set; }
        public double RatePerVisit { get; set; }

        public override double CalculateGrossPayout()
        {
            return ConsultationsCount * RatePerVisit;
        }

        public override double CalculateTax(double grossPayout)
        {
            return 0.10; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- HealthSync Advanced Billing ---");
            Console.Write("Enter Consultant Type (1: In-House, 2: Visiting): ");
            string type = Console.ReadLine();

            Consultant consultant = null;

            if (type == "1")
            {
                var inHouse = new InHouseConsultant();
                
                Console.Write("Enter Consultant ID: ");
                inHouse.ConsultantId = Console.ReadLine();

                if (!inHouse.ValidateConsultantId())
                {
                    Console.WriteLine("Invalid doctor id");
                    return;
                }

                Console.Write("Enter Monthly Stipend: ");
                inHouse.MonthlyStipend = double.Parse(Console.ReadLine());
                
                consultant = inHouse;
            }
            else if (type == "2")
            {
                var visiting = new VisitingConsultant();

                Console.Write("Enter Consultant ID: ");
                visiting.ConsultantId = Console.ReadLine();

                if (!visiting.ValidateConsultantId())
                {
                    Console.WriteLine("Invalid doctor id");
                    return;
                }

                Console.Write("Enter Consultations Count: ");
                visiting.ConsultationsCount = int.Parse(Console.ReadLine());

                Console.Write("Enter Rate Per Visit: ");
                visiting.RatePerVisit = double.Parse(Console.ReadLine());

                consultant = visiting;
            }
            else
            {
                Console.WriteLine("Invalid Selection.");
                return;
            }

            
            double gross = consultant.CalculateGrossPayout();

            double taxRate = consultant.CalculateTax(gross);

            double taxAmount = gross * taxRate;
            double netPayout = gross - taxAmount;

            Console.WriteLine($"Gross: {gross:F2} | TDS Applied: {taxRate * 100}% | Net Payout: {netPayout:F2}");
        }
    }
}