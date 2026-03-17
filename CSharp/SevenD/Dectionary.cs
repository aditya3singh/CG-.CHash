using System;
using System.Collections.Generic;

class Dictionary
{
    public static void DictionaryArr()
    {
        Dictionary<int, string> dict = new Dictionary<int, string>();
        dict.Add(1, "One");
        dict.Add(2, "Two"); 
        dict.Add(3, "Three");
        // foreach(int n in dict.Keys)
        // {
        //     Console.WriteLine("Key: " + n + ", Value: " + dict[n]);

        // }
        for(int i = 1; i <= dict.Count; i++)
        {
            Console.WriteLine("Key: " + i + ", Value: " + dict[i]);
        }

        foreach(KeyValuePair<int, string> dck in dict)
        {
            Console.WriteLine("Key: " + dck.Key + ", Value: " + dck.Value);
        }
        //why for loop not working?
        // Answer: Dictionary is not ordered collection, so for loop based on index will not work reliably.
        //what is dict.Count?
        // Answer: dict.Count returns the number of key-value pairs in the dictionary.  
        //whatis KeyValuePair?
        // Answer: KeyValuePair is a structure that holds a key and a value as a single unit.
    }

}
