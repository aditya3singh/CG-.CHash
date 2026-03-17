using System;

class CG
{
    public static void Game()
    {
        int emy = 0;
        while(emy < 10)
        {
            if(emy == 4)
            {
                Console.WriteLine("Emy 4 is invisible. Skipping emy 4");
            }
            else
            {
                Console.WriteLine($"Player killed Emy{emy}");
            }
            emy++;
        }
        Console.WriteLine("Game End");
    }
}