//class Program
//{
//    static void Main()
//    {
//        try
//        {
//            //user input validation
//            Console.Write("Enter withdrawal amount: ");
//            decimal amount = decimal.Parse(Console.ReadLine());

//            int serviceCharge = 100;
//            // int divisionCheck= serviceCharge/int.Parse("0"); // intentional error

//            //File Access
//            string data = File.ReadAllText("account.txt");

//            //Business Logic
//            BankAccount account = new BankAccount();
//            account.Withdraw(amount);
//            Console.WriteLine("Withdrawal successful");
//        }

//        catch (FormatException ex)
//        {
//            LogException(ex);
//            Console.WriteLine("Invalid input format");
//        }
//        catch (DivideByZeroException ex)
//        {
//            LogException(ex);
//            Console.WriteLine("Arithmetic error occured.");
//        }
//        catch (FileNotFoundException ex)
//        {
//            LogException(ex);
//            Console.WriteLine("File Not Found.");
//        }
//        catch (InsufficientBalanceException ex)
//        {
//            LogException(ex);
//            Console.WriteLine(ex.Message);
//        }
//        catch (Exception ex)
//        {
//            LogException(ex);
//            Console.WriteLine("An unexcepted error occured.");
//        }
//        finally
//        {
//            Console.WriteLine("Transaction attempt completed.");
//        }
//    }

//    static void LogException(Exception ex)
//    {

//        File.AppendAllText(
//            "error.log",
//            DateTime.Now + " | " + ex.GetType().Name + " | " + ex.Message + Environment.NewLine);

//    }
//}


/*
 
 
using System;
using System.IO;

class Program
{
    static void Main()
    {
        FileStream file = null;

        try
        {
            // Try to open the file
            file = new FileStream("data.txt", FileMode.Open);

            // Read one byte from the file
            int data = file.ReadByte();

            Console.WriteLine("First byte read from file: " + data);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
        finally
        {
            // This block always runs
            if (file != null)
            {
                file.Close();
                Console.WriteLine("File stream closed in finally block.");
            }
        }

        Console.WriteLine("Program finished.");
    }
}

 */


using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            try
            {
                // Attempt to read a file
                File.ReadAllText("transactions.txt");
            }
            catch (IOException ioEx)
            {
                // Wrap original exception inside a custom exception
                throw new ApplicationException(
                    "Unable to load transaction data",
                    ioEx
                );
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Message: " + ex.Message);

            if (ex.InnerException != null)
            {
                Console.WriteLine("Root Cause: " + ex.InnerException.Message);
            }
        }
    }
}
