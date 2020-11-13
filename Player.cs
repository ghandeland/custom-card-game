using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class Player
    {
        public int Id { get; set; }

        public List<Card> Hand { get; set; }
        public Player(int id, List<Card> hand)
        {
            Id = id;
            Hand = hand;
        }


        //public int DrawCard(Card card)
        //{
        //    string player1 = "Adrian";
        //    Console.WriteLine(_playername + "receiving card:" + card);
        //    return _cardsInhand++;
        //}

        //public void winConditionMet(int suitsInHands)
        //{

        //    if (suitsInHands > 3)
        //    {
        //        Console.WriteLine("We have a wiener");
        //    }
        //}

    }

}
