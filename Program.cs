using System;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Hi! Welcome to this wonderful card game");
            Console.WriteLine("How many players? (2-4) ");
            bool gameNotStarted = true;

            while (gameNotStarted)
            {
                int playerAmount = Convert.ToInt32(Console.ReadLine());

                if (playerAmount < 2 || playerAmount > 4)
                {
                    Console.WriteLine("Please enter a number between 2 and 4");
                }
                else
                {
                    gameNotStarted = false;
                    Game game = new Game(playerAmount);
                    game.StartGame();

                }



            }
        }
    }
}
