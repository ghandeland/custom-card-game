using System;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(2);
            game.StartGame();


            /*Console.WriteLine("Hi! Welcome to this wonderfull card game");
            Console.WriteLine("How many players? (2-4)");
            bool gameNotStarted = true;
            int playerAmount = Convert.ToInt32(Console.ReadLine());
            while (gameNotStarted) { 
                
            
                if(playerAmount < 2 || playerAmount > 4)
                {
                    Console.WriteLine("Please enter a number between 2 and 4");
                    playerAmount = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                        gameNotStarted = false;
                        Game game = new Game(playerAmount);
                        game.StartGame();
                        bool playAgain = false;

                    while (!playAgain)
                    {

                        Console.WriteLine("Do you want to play again? (Y/N)");
                        String playAgainAnswer = (Console.ReadLine());
                        if (playAgainAnswer.ToLower().Equals("y"))
                        {
                            playAgain = true;

                        }
                        else
                        {
                            return;
                        }

                        gameNotStarted = true;


                    }
                }   
           }
        }*/
        }
    }
}
