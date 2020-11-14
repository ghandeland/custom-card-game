using System;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Dealer dealer = new Dealer(deck);
            Player player1 = new Player(1, dealer);
            Player player2 = new Player(2, dealer);
            player1.Start();
            player2.Start();


        }
    }
}
