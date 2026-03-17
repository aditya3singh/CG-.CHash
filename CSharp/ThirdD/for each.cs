using System;
using System.Diagnostics.CodeAnalysis;

// class For
// {
//     public static int Sum(params int[] nums)
//     {
//         int total = 0;
//         foreach (int n in nums)
//         {
//             total += n;
//         }
//         total += a;
//         return total;
//     }
// }

using System;

class For
{
    public static int Sum(params int[] nums)
    {
        int total = 0;
        foreach (int n in nums)
        {
            total += n;
        }
        

        return total;
    }
}


