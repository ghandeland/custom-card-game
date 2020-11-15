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

        public ICard DealCard()
        {
            lock (_deckLock)
            {
                if (_deck.DeckList.Count < 1)
                {
                    return null;
                }

                int randomIndex = _random.Next(_deck.DeckList.Count);
                ICard cardToDeal = SerializeCardObj(_deck.DeckList[randomIndex]);
                _deck.DeckList.RemoveAt(randomIndex);
                return cardToDeal;
            }
        }

        private ICard SerializeCardObj(ICard card)
        {
            string cardToJson = JsonConvert.SerializeObject(card);
            Console.WriteLine(cardToJson);
            if (card.GetType() == typeof(SuitedCard))
            {
                SuitedCard cardToDeal = JsonConvert.DeserializeObject<SuitedCard>(cardToJson);
                return cardToDeal;
            }
            else
            {
                SpecialCard cardToDeal = JsonConvert.DeserializeObject<SpecialCard>(cardToJson);
                return cardToDeal;
            }
             
        }

        public ICard DealSuitedCard()
        {
            // Maybe a separate class for special cards with method amountOfSpecialCards() to place here?
            if (_deck.DeckList.Count < 5)
            {
                return null;
            }

            Boolean normalCardDrawn = false;

            while (!normalCardDrawn)
            {
                int index = _random.Next(_deck.DeckList.Count);
                ICard drawnCard = _deck.DeckList[index];

                if (drawnCard.GetType() == typeof(SuitedCard))
                {
                    ICard cardToDeal = SerializeCardObj(drawnCard);
                    _deck.DeckList.RemoveAt(index);
                    normalCardDrawn = true;
                    return cardToDeal;
                }
            }
            return null;
        }




    }
}
