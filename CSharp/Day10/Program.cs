using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        //string input = "123_123";

        //string pattern1 = @"\d";     
        //string pattern2 = @"\d*";    
        //string pattern3 = @"\D";     
        //string pattern4 = @"\d+";    
        //string pattern5 = @"\w";

        //bool isDigitPresent = Regex.IsMatch(input, pattern1);

        //Match match1 = Regex.Match("Amount : 5000", pattern1);
        //Match match2 = Regex.Match(input, pattern2);
        //Match match3 = Regex.Match("10A20B30C", pattern3);

        //MatchCollection digitMatches = Regex.Matches("10 20 30", pattern4);
        //MatchCollection wordMatches = Regex.Matches("Hello_123 World", pattern5);

        //Console.WriteLine("Input String: " + input);
        //Console.WriteLine("Does it contain a digit? " + isDigitPresent);

        //Console.WriteLine("First Digit Found: " + match1.Value);
        //Console.WriteLine("Digits from input: " + match2.Value);
        //Console.WriteLine("First NON-Digit Found: " + match3.Value);
        //string pattern6 = @"\W";
        //string pattern6 = @"\.txt";
        //string input = "10a20b30c!@_abc";
        //string input = "10a20b30c!@_abc _0! \t,file.txt";
        //string pattern6 = @"\\";
        //string pattern6 = @"\?";
        //string input = "10a20b30c!@_abc _0! \t,C:\\abc\\file.txt";
        //string input = "?10a20b30c!@_abc _0! \t,C:\\abc\\file.txt?";
        //string pattern6 = @"lo$";
        //string pattern6 = @"Hello$";//Dollor is looking for the end of the string
        //string input = "?10a20b30c!@_abc _0! \t,C:\\abc\\file.txt?Hello";


        //string pattern6 = @"^Hello$";
        //string pattern6 = @"^Hello$";
        //string input = "Hello?10a20b30c!@_abc _0! \t,C:\\abc\\file.txt?";
        //string pattern6 = @"Amount=(?<value>\d+)";
        //string pattern7 = @"(?<year>\d{4})-(?<month>\d{2})-(?<date>\d{2})-";
        ////string input = "Hello?10a20b30c!@_abc _0! \t,C:\\abc\\file.txt?";
        //string input = "23-02-1992"
        //string Input = "1992-02-23, 1990-01-01"
        //MatchCollection wordMatches1 = Regex.Matches(input, pattern6);

        //Console.WriteLine("Non-word characters found:");

        //foreach (Match match in wordMatches1)
        //{
        //    Console.WriteLine(match.Value);
        //}

        //Match m = Regex.Match(input, pattem); // 1992
        //Match m = Regex.Matches(input, pattem);

        //string input = "Amount=5000";
        //string pattern = @"Amount=(?<value>\d+)";

        //string input = "apple";
        //string input = "apple a123e a!-@e";
        //string input = "grapple apples a123e a!-@e";
        //string pattern = @"a...e";

        //Match m = Regex.Match(input, pattern);

        //if (m.Success)
        //{
        //    Console.WriteLine("Using Match:");
        //    Console.WriteLine("Amount = " + m.Groups["value"].Value);
        //}

        //input = "1992-02-23, 1990-01-01";
        //pattern = @"(?<year>\d{4})-(?<month>\d{2})-(?<day>\d{2})";

        //MatchCollection matches = Regex.Matches(input, pattern);

        //Console.WriteLine("\nUsing Matches:");
        //foreach (Match match in matches)
        //{
        //    //Console.WriteLine(
        //    //    $"Year: {match.Groups["year"].Value}, " +
        //    //    $"Month: {match.Groups["month"].Value}, " +
        //    //    $"Day: {match.Groups["day"].Value}"
        //    //);
        //    Console.WriteLine(match.Value);
        //}


        Email.Emails();
        //flat1 //flat2 //flat3

    }
}
