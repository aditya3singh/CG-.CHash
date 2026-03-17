using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Email
{
    public static void Emails()
    {
        List<string> Emails = new List<string>
        {
            "john.doe@gmail.com",
            "alice_123@yahoo.in",
            "mark.smith@company.com",
            "support-abc@banking.co.in",
            "user.nametag@domain.org",

            "john.doe@gmail",          // Missing domain extension
            "alice@@yahoo.com",        // Double @
            "mark.smith@.com",         // Domain missing name
            "support@banking..com",    // Double dot in domain
            "user name@gmail.com",     // Space not allowed
            "@domain.com",             // Missing username
            "admin@domain",            // No top-level domain
            "info@domain,com",         // Comma instead of dot
            "finance#dept@corp.com",   // Invalid character #
            "plainaddress"             // Missing @ and domain
        };

        // Email validation pattern
        string pattern = @"^[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        Console.WriteLine("Email Validation Result:\n");

        foreach (string email in Emails)
        {
            bool isValid = Regex.IsMatch(email, pattern);

            Console.WriteLine($"{email,-30} : {(isValid ? "VALID" : "INVALID")}");
        }
    }
}