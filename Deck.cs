using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class Deck
    {
        public List<ICard> DeckList { get; set; }

        public Deck()
        {
            DeckList = FillDeck();
            SetSpecialCards();
            //PrintDeck();
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

                DeckList[specialCards[0]] = new SpecialCard(SpecialCardType.Bomb);
                DeckList[specialCards[1]] = new SpecialCard(SpecialCardType.Vulture);
                DeckList[specialCards[2]] = new SpecialCard(SpecialCardType.Quarantine);
                DeckList[specialCards[3]] = new SpecialCard(SpecialCardType.Joker);
            }
        }

        private List<ICard> FillDeck()
        {
            List<ICard> Deck = new List<ICard>();
            

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
                    Deck.Add(new SuitedCard((k + 1), cSuit));

                }

            }

            return Deck;

        }

        public void PrintDeck()
        {
            foreach (SuitedCard card in DeckList)
            {
                Console.WriteLine(card.getCardInfo());
            }
        }

        public void ReceiveDiscardedDeck(List<ICard> discardDeck)
        {
            foreach (ICard card in discardDeck)
            {
                DeckList.Add(card);
            }
        }
    }                

}


