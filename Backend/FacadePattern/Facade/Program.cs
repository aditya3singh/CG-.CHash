using System;
using System.Text.RegularExpressions;
using System.Globalization;

public class Program
{
    public static string validateTransaction(string record)
    {
        // Split the record into its 5 distinct parts
        string[] parts = record.Split('|');
        if (parts.Length != 5) return "INVALID LOG";

        string idPart = parts[0];
        string datePart = parts[1];
        string currencyPart = parts[2];
        string amountPart = parts[3];
        string statusPart = parts[4];

        // 1. Transaction ID Validation
        // Must match TXN-XXXXXX where first X is 1-9
        if (!Regex.IsMatch(idPart, @"^TXN-[1-9]\d{5}$")) return "INVALID LOG";
        // Cannot have 4 identical consecutive characters anywhere
        if (Regex.IsMatch(idPart, @"(.)\1{3}")) return "INVALID LOG";

        // 2. Date Validation
        // TryParseExact handles leap years and invalid dates (like April 31st) automatically
        if (!DateTime.TryParseExact(datePart, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            return "INVALID LOG";
        // Year must be between 2000 and 2099
        if (date.Year < 2000 || date.Year > 2099) return "INVALID LOG";

        // 3. Currency Validation
        string[] validCurrencies = { "USD", "EUR", "INR", "GBP", "AUD", "CAD" };
        if (Array.IndexOf(validCurrencies, currencyPart) == -1) return "INVALID LOG";

        // 4. Amount Validation
        // Regex ensures no leading zeros (unless exactly 0) and max 2 decimal places
        if (!Regex.IsMatch(amountPart, @"^(0|[1-9]\d*)(\.\d{1,2})?$")) return "INVALID LOG";

        // Parse the amount to check numeric constraints
        if (!decimal.TryParse(amountPart, CultureInfo.InvariantCulture, out decimal amount)) return "INVALID LOG";
        // Must be a positive number and strictly <= 999999.99
        if (amount <= 0 || amount > 999999.99m) return "INVALID LOG";

        // 5. Status Validation
        string[] validStatuses = { "SUCCESS", "FAILED", "PENDING" };
        if (Array.IndexOf(validStatuses, statusPart) == -1) return "INVALID LOG";

        // If it passes all checks, it's valid!
        return "VALID LOG";
    }

    public static void Main(string[] args)
    {
        // Read the number of records
        if (int.TryParse(Console.ReadLine(), out int n))
        {
            // Loop through each record, validate, and print the result
            for (int i = 0; i < n; i++)
            {
                string record = Console.ReadLine();
                Console.WriteLine(validateTransaction(record));
            }
        }
    }
}