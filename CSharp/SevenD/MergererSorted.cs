using System;
using System.Collections.Generic;
using System.Collections;

/*

Merge two sorted arrays into a single sorted array.
Max Time: 10 minutes

Explanation: Demonstrates merging and sorting techniques.

using System;
using System.Linq;
class Program {
    static void Main() {
        int[] arr1 = {1, 3, 5};
        int[] arr2 = {2, 4, 6}

*/
class MergererSorted
{
    public static void MergererSortedArr()
    {
        int[] arr1 = {1, 3, 5};
        int[] arr2 = {2, 4, 6};

        int[] merger = new int[arr1.Length + arr2.Length];
        int i= 0, j=0, k=0;
        while(i < arr1.Length && j < arr2.Length)
        {
            if(arr1[i] < arr2[j])
            {
                merger[k++] = arr1[i++];
            }
            else
            {
                merger[k++] = arr2[j++];
            }

        }
        while(i < arr1.Length)
        {
            merger[k++] = arr1[i++];

        }
        while(j < arr2.Length)
        {
            merger[k++] = arr2[j++];
        }
        Console.WriteLine("Merged: ");
        foreach(int num in merger)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}