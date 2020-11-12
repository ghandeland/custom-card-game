using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class Deck
    {
        private List<Card> _deck;



        public Deck()
        {
            FillDeck();


        }

        private void FillDeck()
        {
            this._deck = new List<Card>();
            List<int> specialCardPicker = new List<int>();

            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 13; k++)
                {
                    Console.WriteLine("Countto52:" + (k + 1 + (j * 13)));
                    CardSuit cSuit;
                    switch (j)
                    {
                        case 0:
                            cSuit = CardSuit.Clubs;
                            break;
                        case 1:
                            cSuit = CardSuit.Diamonds;
                            break;
                        case 2:
                            cSuit = CardSuit.Hearts;
                            break;
                        default:
                            cSuit = CardSuit.Spades;
                            break;
                    }
                    _deck.Add(new Card((k + 1), cSuit, CardType.Normal));

                }

            }
        }

        public void PrintDeck()
        {
            foreach (Card card in _deck)
            {
                card.PrintCardInfo();
            }
        }
    }                



                    //_deck.Add(new Card());
                    //specialCardPicker.Add(j);
   


                // Adding 4 unique index values to array (special cards)
                /*
                Random random = new Random();
                int[] specialCards = new int[4];
                for (int k = 0; k < 4; k++)
                {
                    int specialCardIndex = random.Next(specialCardPicker.Count);
                    specialCards[k] = specialCardPicker[specialCardIndex];
                    specialCardPicker.RemoveAt(specialCardIndex);
                }

                _deck[specialCards[0]] = CardType.Bomb;
                _deck[specialCards[1]] = CardType.Vulture;
                _deck[specialCards[2]] = CardType.Quarantine;
                _deck[specialCards[3]] = CardType.Joker;

                foreach (CardType c in _deck)
                {
                    Console.WriteLine(c.ToString());
                }
                */
}


