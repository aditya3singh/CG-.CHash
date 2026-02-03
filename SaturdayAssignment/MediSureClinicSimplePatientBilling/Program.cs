
class Program
{
    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("MediSure Clinic Billing");
            Console.WriteLine("1. Create New Bill (Enter Patient Details)");
            Console.WriteLine("2. View Last Bill");
            Console.WriteLine("3. Clear Last Bill");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    PatientBill.CreateNewBill();
                    break;
                case "2":
                    PatientBill.ViewLastBill();
                    break;
                case "3":
                    PatientBill.ClearLastBill();
                    break;
                case "4":
                    exit = true;
                    Console.WriteLine("Thank you. Application closed normally.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
