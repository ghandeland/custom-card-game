using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Newtonsoft.Json;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class Card
    {

        public int Value { get; set; }
        public CardSuit Suit { get; set; }
        public CardType Type { get; set; }

        public Card(int value, CardSuit suit, CardType type)
        {
            this.Value = value;
            this.Suit = suit;
            this.Type = type;
        }

        public Card() { }

        public string getCardInfo()
        {
            return(this.Value + " of " + this.Suit.ToString() + " Type: " + this.Type.ToString());
        }
        public static string serializeCard(Card card)
        {
            return JsonConvert.SerializeObject(card);
        }

        public static Card DeserializeCard(string jsonCard)
        {
            Card card = JsonConvert.DeserializeObject<Card>(jsonCard);

            return card;
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
