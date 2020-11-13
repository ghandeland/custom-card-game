using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class Deck
    {
        public List<Card> DeckList { get; set; }

        public Deck()
        {
            DeckList = FillDeck();
            SetSpecialCards();
            PrintDeck();
        }

        private void SetSpecialCards()
        {
            if (DeckList != null)
            {
                Random random = new Random();
                List<int> deckIndexes = new List<int>();
                int[] specialCards = new int[4];

                for (int i = 0; i < DeckList.Count; i++)
                {
                    deckIndexes.Add(i);
                }

                for (int k = 0; k < specialCards.Length; k++)
                {
                    int randomIndex = random.Next(deckIndexes.Count);
                    specialCards[k] = deckIndexes[randomIndex];
                    deckIndexes.RemoveAt(randomIndex);
                }

                DeckList[specialCards[0]].Type = CardType.Bomb;
                DeckList[specialCards[1]].Type = CardType.Vulture;
                DeckList[specialCards[2]].Type = CardType.Quarantine;
                DeckList[specialCards[3]].Type = CardType.Joker;
            }
        }

        private List<Card> FillDeck()
        {
            List<Card> Deck = new List<Card>();
            

            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 13; k++)
                {
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
                    Deck.Add(new Card((k + 1), cSuit, CardType.Normal));

                }

            }

            return Deck;

        }

        public void PrintDeck()
        {
            foreach (Card card in DeckList)
            {
                card.PrintCardInfo();
            }
        }
    }                


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


