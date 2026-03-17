using System;

class PT
{
    public static void PrintTable()
    {
       

        for(int i = 20; i<= 30; i++)
        {
            for(int j= 1; j<= 10; j++)
            {
                Console.WriteLine($"{i} * {j} = "+i * j);
            }
        }
    }
}