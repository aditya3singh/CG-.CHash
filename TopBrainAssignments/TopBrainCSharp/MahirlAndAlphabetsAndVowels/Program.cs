class Program
{
    public static void Main()
    {
        string str1 = Console.ReadLine();
        string str2 = Console.ReadLine();
        string result = "";
        for(int i= 0; i< str1.Length; i++)
        {
            char ch = char.ToLower(str1[i]);
            if (IsVowel(ch))
            {
                result += str1[i];
            }
            else
            {
                if (!str2.ToLower().Contains(ch))
                {
                    result += str2[i];
                }
            }
        }
        string finalResult = "";
        for(int i = 0; i < result.Length; i++)
        {
            if (i == 0 || result[i] != result[i - 1])
            {
                finalResult += result[i];
            }
        }
        Console.WriteLine(finalResult);
    }

    static bool IsVowel(char ch)
    {
        return ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u';
    }
}