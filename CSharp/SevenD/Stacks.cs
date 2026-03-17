using System;
using System.Collections;
using System.Collections.Generic;

class Stacks
{
    public static void StacksArr()
    {
        Stack stack = new Stack();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        foreach(int stackElement in stack)
        {
            Console.WriteLine(stackElement);
        }
    }
}