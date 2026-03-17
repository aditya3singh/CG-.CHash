using System;
using System.IO;

class ExceptionDemo
{
    static void Main()
    {
        try
        {
            try
            {
                File.ReadAllText("transactions.txt");
            }
            catch (IOException ioEx)
            {
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
