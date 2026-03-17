using System;
using System.Text.RegularExpressions;

namespace LogProcessing
{
    public class LogParsers
    {
        private readonly string validLineRegexPattern = @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]";
        private readonly string splitLineRegexPattern = @"<\*{3}>|<={4}>|<\^\*>";
        private readonly string quotedPasswordRegexPattern = "\"[^\"]*password[^\"]*\"";
        private readonly string endOfLineRegexPattern = @"end-of-line\d+";
        private readonly string weakPasswordRegexPattern = @"\bpassword\w*\b";


        public bool IsValidLogLine(string text)
        {
            return Regex.IsMatch(text, validLineRegexPattern);
        }

        public string[] SplitLogLine((string text){
            return Regex.Split(text, splitLineRegexPattern);
        }

        public int CountQuotedPasswords(string line)
        {
            MatchCollection matches = Regex.Matches(
                line,
                quotedPasswordRegexPattern,
                RegexOptions.IgnoreCase
            );
            return matches.Count;
        }

        public string RemoveEndOfLineText(string line)
        {
            return Regex.Replace(line, endOfLineRegexPattern, "");
        }

        public string[] ListLinesWithPasswords(string[] line)
        {
            string[] result = new string[line.Length];
            for(int i= 0; i< line.Length; i++)
            {
                Match m = Regex.Match(line[i], weakPasswordRegexPattern, RegexOptions.IgnoreCase);
                if (m.Success)
                {
                    result[i] = $"{m.Value}: {lines[i]}";
                }
                else
                {
                    result[i] = $"{line[i]}";
                }
            }
            return result;
        }
    }
}