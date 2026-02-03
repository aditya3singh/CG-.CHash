using System.Diagnostics.Tracing;

class Program
{
    public static void Main()
    {
        string str = Console.ReadLine();
        str = str.Trim();
        string result = "";

        for(int i = 0; i< str.Length; i++)
        {
            if(i > 0 && str[i] == str[i - 1])
            {
                continue;
            }
            if (i == 0 || str[i - 1] == ' ')
            {
                result += char.ToUpper(str[i]);
            }
            else
            {
                result += char.ToLower(str[i]);
            }
        }

        Console.WriteLine(result);
    }
}