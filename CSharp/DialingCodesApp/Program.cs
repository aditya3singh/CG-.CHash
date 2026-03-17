using System;
using System.Collections.Generic;
using DialingCodesApp;  


class Program
{
    static void Main()
    {
        Dictionary<int, string> emptyDict = DialingCodes.GetEmptyDictionary();
        Console.WriteLine("Empty Dictionary Count: " + emptyDict.Count);

        Dictionary<int, string> existingDict = DialingCodes.GetExistingDictionary();
        Console.WriteLine("\nPredefined Dictionary:");
        PrintDictionary(existingDict);

        var japanDict = DialingCodes.AddCountryToEmptyDictionary(81, "Japan");
        Console.WriteLine("\nAfter Adding Japan:");
        PrintDictionary(existingDict);

        Console.WriteLine("\nCountry for code 91: " + DialingCodes.GetCountryNameFromDictionary(existingDict, 91));
        Console.WriteLine("Does code 99 exist? " + DialingCodes.CheckCodeExists(existingDict, 99));

        DialingCodes.UpdateDictionary(existingDict, 91, "Republic of India");
        Console.WriteLine("\nAfter Updating India:");
        PrintDictionary(existingDict);

        DialingCodes.RemoveCountryFromDictionary(existingDict, 1);
        Console.WriteLine("\nAfter Removing USA:");
        PrintDictionary(existingDict);

        // Task 9: Find Longest Country Name
        Console.WriteLine("\nLongest Country Name: " + DialingCodes.FindLongestCountryName(existingDict));
    }

    static void PrintDictionary(Dictionary<int, string> dict)
    {
        foreach (var item in dict)
        {
            Console.WriteLine($"{item.Key} : {item.Value}");
        }
    }

}