using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class Card
    {

        public int Value { get; private set; }
        public CardSuit Suit { get; private set; }
        public CardType Type { get; set; }

        public Card(int value, CardSuit suit, CardType type)
        {
            this.Value = value;
            this.Suit = suit;
            this.Type = type;
        }

        public void PrintCardInfo()
        {
            Console.WriteLine(this.Value + " of " + this.Suit.ToString() + " Type: " + this.Type.ToString());
        }
    }


    enum CardType
    {
        Normal,
        Bomb,
        Vulture,
        Quarantine,
        Joker
    }

    enum CardSuit
    {
        Hearts,
        Spades,
        Clubs,
        Diamonds
    }

}
