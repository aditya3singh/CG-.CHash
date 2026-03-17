/*
int[] numbers;

initialization with Size
int[] numbers = new int[5];

int[] numbers = new int[] { 1, 2, 3, 4, 5 };

//why array is needed? if list is there?
//Arrays are of fixed size, which can lead to better performance and lower memory overhead in certain scenarios.


what is the [,] in array?
A two-dimensional array, also known as a matrix, is declared using a comma within the square brackets. For example, int[,] matrix = new int[3,4]; declares a 2D array with 3 rows and 4 columns.

int [,] matrix = new int[3, 4];
int [,] matrix = {
  {1, 2, 3, 4},
  {5, 6, 7, 8},
  {9, 10, 11, 12}
};

*/

using System;
using System.Reflection.Metadata;
class Arrays
{
    public static void Arr()
    {
        // int[] nums = { 1, 2, 3, 4, 5 };

//         int[,] matrix = {
//   {1, 2, 3, 4},
//   {5, 6, 7, 8},
//   {9, 10, 11, 12}
// };

        // foreach (int n in matrix)
        // {
        //     if(n == 4)
        //     {
        //         Console.WriteLine("Found");
        //     }
        // }
        // // Console.WriteLine("Not Found");

        // 
        
        int[][] jaggedArray = new int[3][];
        jaggedArray[0] = new int[]{ 1, 2 };
        jaggedArray[1] = new int[]{ 3, 4, 5 };
        jaggedArray[2] = new int[] { 6 };
        for( int i= 0; i< jaggedArray.Length; i++)
        {
            for(int j= 0; j< jaggedArray[i].Length; j++)
            {
                Console.WriteLine(jaggedArray[i][j]);
            }
        }
    }
}

//explain me this for(int j= 0; j< jaggedArray[i].Length; j++)
//This line is part of a nested loop that iterates through each element of a jagged array in C#.
//Here's a breakdown of the components:
//for(int j= 0; j< jaggedArray[i].Length; j++)
//1. Initialization: int j = 0; - This initializes the loop counter j to 0, which will be used to access elements within the inner array.
//2. Condition: j < jaggedArray[i].Length; - This condition checks whether j is less than the length of the inner array located at index i of the jagged array. jaggedArray[i] refers to the specific inner array, and .Length gives the number of elements in that inner array.
//3. Increment: j++ - This increments the loop counter j by 1 after each iteration of the loop.
//The loop will continue to execute as long as j is less than the length of the inner array, allowing you to access and process each element within that inner array using jaggedArray[i][j].   


//getlength() method in array
//The GetLength() method in C# is used to retrieve the number of elements along a specified dimension of an array.
//For example, in a two-dimensional array, GetLength(0) returns the number of rows, while GetLength(1) returns the number of columns.

//Jagged Arrays in C#
//A jagged array is an array of arrays, meaning that each element of the main array can hold a reference to another array, and these inner arrays can have different lengths.
//Example of Jagged Array   
// int[][] jaggedArray = new int[3][];
// jaggedArray[0] = new int[] { 1, 2 };
