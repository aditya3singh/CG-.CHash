class Program
{
    static void Main()
    {
        var parser = new LogProcessing.LogParser();

        Console.WriteLine(parser.IsValidLine("[ERR] Disk failure")); // true
        Console.WriteLine(parser.IsValidLine("Disk failure"));       // false

        string log = "Part1<***>Part2<====>Part3<^*>Part4";
        var parts = parser.SplitLogLine(log);

        string text = "\"password123\" failed \"PASSWORD reset\"";
        Console.WriteLine(parser.CountQuotedPasswords(text)); // 2

        Console.WriteLine(parser.RemoveEndOfLineText("Error end-of-line45"));

        string[] lines =
        {
            "User password123 failed login",
            "System started successfully"
        };

        var output = parser.ListLinesWithPasswords(lines);
        foreach (var line in output)
            Console.WriteLine(line);
    }
}
