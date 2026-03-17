/*
Find the frequency of elements in an array using a Dictionary
int[] arr = {1, 2, 3, 2, 1, 4, 2};

*/

using System;
using System.Collections.Generic;

class Frequency
{
    public static void FrequencyArr()
    {
        int[] nums = {1, 2, 3, 2, 1, 4, 2};
        Dictionary<int, int> freq = new Dictionary<int, int>();
        foreach(int num in nums)
        {
            if (freq.ContainsKey(num))
            {
                freq[num]++;
            }
            else
            {
                freq[num] = 1;
            }
        }
        Console.WriteLine("Element Frequencies:");
        foreach(var pair in freq)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}