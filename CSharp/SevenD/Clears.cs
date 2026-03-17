using System;

class Clear
{
    // public static void ClearArr()
    // {
    //     int[] nums = { 1, 2, 3, 4, 5 };
    //     Array.Clear(nums,  1, nums.Length - 2); 
    //     foreach(int n in nums)
    //     {
    //         Console.WriteLine(n);
    //     }


    // }
    public static void CopyArr()
    {
        int[] source = { 1, 2, 3 };
        int[] destination = new int[3];
        int[] destination2 = new int[3];
        int[] destination3 = new int[3];
        Array.Copy(source, destination, 1);
        Array.Copy(source, destination2, 2);
        Array.Copy(source, destination3, 3);
        foreach(int n in destination)
        {
            Console.WriteLine(n);
            
        }

    }

}