using System;
using System.Collections.Generic;
using System.Collections;


class Assignment
{
    public static string CleanseAndInvert(string input)
    {
        //first take the input and check for null or length less than 6 and then if valid then reverse the string after removing even ascii characters and then change even positioned characters to uppercase
        if(string.IsNullOrEmpty(input) || input.Length < 6)
        {
            return "";
   
        }
        foreach(char c in input)
        {
            if (!char.IsLetter(c))
            {
                return "";
            }
        }

        string LowerInput = input.ToLower();
        string filtered = "";
        foreach(char c in LowerInput)
        {
            if((int) c % 2 != 0)
            {
                filtered += c;
            }
        }
        char[] charArray = filtered.ToCharArray();
        Array.Reverse(charArray);
        string reversed = new string(charArray);
        char[] finalArray = reversed.ToCharArray();//
        for(int i= 0; i< finalArray.Length; i++)
        {
            if(i % 2 == 0)
            {
                finalArray[i] = char.ToUpper(finalArray[i]);
            }

        }
        return new string(finalArray);
    }
}