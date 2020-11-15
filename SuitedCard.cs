using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Newtonsoft.Json;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class SuitedCard : ICard
    {

        public int Value { get; set; }
        public CardSuit Suit { get; set; }

        public SuitedCard(int value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
            
        }

        public SuitedCard() { }

        public string getCardInfo()
        {
            return(this.Value + " of " + this.Suit.ToString());
        }
        public static string serializeCard(SuitedCard suitedCard)
        {
            return JsonConvert.SerializeObject(suitedCard);
        }

        public static SuitedCard DeserializeCard(string jsonCard)
        {
            SuitedCard suitedCard = JsonConvert.DeserializeObject<SuitedCard>(jsonCard);

            return suitedCard;
        }



    }

    enum CardSuit
    {
        Hearts,
        Spades,
        Clubs,
        Diamonds
    }

}
