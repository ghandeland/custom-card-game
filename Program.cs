using System;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Hi! Welcome to this CUSTOM card game");
            Console.WriteLine("How many players? (2-4)");
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
                    bool replay = true;
                    while(replay)
                    {
                        gameNotStarted = false;
                        Game game = new Game(playerAmount);
                        game.StartGame();
                        bool answer = false;
                        while(!answer)
                        {
                            if(game.IsOver)
                            {
                                Console.WriteLine("Do you want to play again? (Y/N)");
                                string answerString = Console.ReadLine();
                                if (answerString.ToLower().Equals("y"))
                                {
                                    answer = true;
                                }
                                else if (answerString.ToLower().Equals("n"))
                                {
                                    replay = false;
                                    answer = true;
                                }
                            }
                            
                        }
                    }
                    

                }



            }
        }
    }
}
