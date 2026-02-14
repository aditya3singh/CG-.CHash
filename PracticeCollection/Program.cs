using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        //Match match = Regex.Match("Amout is 5000", @"\d");
        //Console.WriteLine(match);

        //----------------------------------------------------------------
        //MatchCollection matches = Regex.Matches("10x 20d 30", @"\d+");
        //foreach(Match match in matches)
        //{
        //    Console.WriteLine(match);
        //}

        //---------------------------------------------------------------------

        //string result = Regex.Replace("Abs1234", @"\d", "*");
        //Console.WriteLine(result);
        //Match m = Regex.Match("Date: 2003-01-29", @"(\d{4})-(\d{2})-(\d{2})");

        //Console.WriteLine(m.Value);

        //Match m = Regex.Match("2003-01-29", @"(?<year>\d{4})-(?<month>\d{2})-(?<day>\d{2})");

        //Console.WriteLine(m.Groups["year"].Value); // Output: 2003

        Match user = Regex.Match("user123")
    }
}