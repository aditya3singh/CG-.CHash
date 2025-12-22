class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Banking System");

        Console.Write("Enter Account Number: ");
        int accNo;
        while (!int.TryParse(Console.ReadLine(), out accNo))
        {
            Console.Write("Invalid input. Enter valid Account Number: ");
        }

        Console.Write("Enter Initial Balance: ");
        double initBalance;
        while (!double.TryParse(Console.ReadLine(), out initBalance))
        {
            Console.Write("Invalid input. Enter valid Balance: ");
        }

        BankAccount account = new BankAccount(accNo, initBalance);

        int choice;
        do
        {
            Console.WriteLine("\n1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Display Account");
            Console.WriteLine("4. Exit");
            Console.Write("Choose option: ");

            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    Console.Write("Enter deposit amount: ");
                    double depAmount;
                    if (double.TryParse(Console.ReadLine(), out depAmount))
                        account.Deposit(depAmount);
                    else
                        Console.WriteLine("Invalid amount.");
                    break;

                case 2:
                    Console.Write("Enter withdrawal amount: ");
                    double wAmount;
                    if (double.TryParse(Console.ReadLine(), out wAmount))
                    {
                        if (account.Withdraw(wAmount, out string msg))
                            Console.WriteLine(msg);
                        else
                            Console.WriteLine(msg);
                    }
                    else
                        Console.WriteLine("Invalid amount.");
                    break;

                case 3:
                    account.Display();
                    break;

                case 4:
                    Console.WriteLine("Thank you for banking with us!");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 4);
    }
}
