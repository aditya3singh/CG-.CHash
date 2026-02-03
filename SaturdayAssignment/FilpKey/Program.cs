using System;

public class Program
{
    public string CleanseAndInvert(string input)
    {
        if (input == null)
        {
            return "";
        }

        if (input.Length < 6)
        {
            return "";
        }

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar == ' ')
            {
                return "";
            }

            if (currentChar >= '0' && currentChar <= '9')
            {
                return "";
            }

            if (!((currentChar >= 'a' && currentChar <= 'z') || (currentChar >= 'A' && currentChar <= 'Z')))
            {
                return "";
            }
        }

        string lowercaseInput = input.ToLower();

        string filteredString = "";
        for (int i = 0; i < lowercaseInput.Length; i++)
        {
            char currentChar = lowercaseInput[i];
            int asciiValue = (int)currentChar;

            if (asciiValue % 2 != 0)
            {
                filteredString = filteredString + currentChar;
            }
        }

        string reversedString = "";
        for (int i = filteredString.Length - 1; i >= 0; i--)
        {
            reversedString = reversedString + filteredString[i];
        }

        string result = "";
        for (int i = 0; i < reversedString.Length; i++)
        {
            char currentChar = reversedString[i];

            if (i % 2 == 0)
            {
                if (currentChar >= 'a' && currentChar <= 'z')
                {
                    currentChar = (char)(currentChar - 32);
                }
            }

            result = result + currentChar;
        }

        return result;
    }

    public static void Main(string[] args)
    {
        Program program = new Program();

        Console.WriteLine("Enter the word");
        string userInput = Console.ReadLine();

        string generatedKey = program.CleanseAndInvert(userInput);

        if (generatedKey == "")
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine("The generated key is - " + generatedKey);
        }
    }
}
