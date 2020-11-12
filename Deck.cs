using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class Deck
    {
        private List<Card> deckList;



        public Deck()
        {
            FillDeck();


        }

        private void FillDeck()
        {
                // deckArray - Card (enum) values from index 0 - 51
                // specialCardPicker - List of potential index values to add special cards in deck

                this.deckList = new List<Card>();
                List<int> specialCardPicker = new List<int>();

                for (int j = 0; j < 52; j++)
                {
                    deckList.Add(Card.Normal);
                    specialCardPicker.Add(j);
                }


                // Adding 4 unique index values to array (special cards)

                Random random = new Random();
                int[] specialCards = new int[4];
                for (int k = 0; k < 4; k++)
                {
                    int specialCardIndex = random.Next(specialCardPicker.Count);
                    specialCards[k] = specialCardPicker[specialCardIndex];
                    specialCardPicker.RemoveAt(specialCardIndex);
                }

                deckList[specialCards[0]] = Card.Bomb;
                deckList[specialCards[1]] = Card.Vulture;
                deckList[specialCards[2]] = Card.Quarantine;
                deckList[specialCards[3]] = Card.Joker;

                foreach (Card c in deckList)
                {
                    Console.WriteLine(c.ToString());
                }
        }
    }

    enum Card
    {
        Normal,
        Bomb,
        Vulture,
        Quarantine,
        Joker
    }

}
