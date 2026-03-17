using System;

using System.Collections.Generic;

class Collections
{
    public static void CollectionsArr()
    {
        List<int> nums = new List<int>();
        nums.Add(6);

        foreach(int n in nums)
        {
            Console.WriteLine(n);
            
        }
    }
}