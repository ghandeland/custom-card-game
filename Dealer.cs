using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class Dealer
    {
        private Object _deckLock = new Object();
        private Deck _deck;
        private Random _random;

        public Dealer(Deck deck)
        {
            _deck = deck;
            _random = new Random();
        }

        public string DealCard()
        {
            lock (_deckLock)
            {
                if (_deck.DeckList.Count < 1)
                {
                    return null;
                }

                int randomIndex = _random.Next(_deck.DeckList.Count);
                Card drawnCard = _deck.DeckList[randomIndex];
                string cardToJson = Card.serializeCard(drawnCard);
                _deck.DeckList.RemoveAt(randomIndex);
                return cardToJson;
            }
        }


        public string DealNormalCard()
        {
            // Maybe a separate class for special cards with method amountOfSpecialCards() to place here?
            if (_deck.DeckList.Count < 5)
            {
                return null;
            }

            String cardToJson = "";
            Boolean normalCardDrawn = false;

            while (!normalCardDrawn)
            {
                int index = _random.Next(_deck.DeckList.Count);
                Card drawnCard = _deck.DeckList[index];

                if (drawnCard.Type.Equals(CardType.Normal))
                {
                    cardToJson = Card.serializeCard(drawnCard);
                    _deck.DeckList.RemoveAt(index);
                    normalCardDrawn = true;
                }
            }
            return cardToJson;
        }


    }
}
