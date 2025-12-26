using System;

class ReSizess
{
    public static void ReSizessArr()
    {
        int[] nums = { 1, 2, 3, 4, 5 };
        int[] nums2 = { 1, 2, 3, 4, 5 };
        // Array.Resize(ref nums, 10);
        Array.Resize(ref nums2, 1);
        foreach(int n in nums2)
        {
            Console.WriteLine(n);
        }
    }
}