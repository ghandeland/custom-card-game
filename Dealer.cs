using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace Kristiania.PG3302_1.CustomCardGame
{
    public class Dealer : IDealer
    {
        private Object _deckLock = new Object();
        private Deck _deck;
        private Random _random;
        private List<ICard> _discard;
        public bool GameIsRunning { get; set; }

        public Dealer(Deck deck)
        {
            _deck = deck;
            _random = new Random();
            _discard = new List<ICard>();
            GameIsRunning = true;
        }

         public ICard DealCard(Player player)
         {
            
            lock (_deckLock)
            {
                if(GameIsRunning) 
                { 
                    
                    if (_deck.DeckList.Count < 5)
                    {
                        moveDiscardDeckToNormalDeck();
                    }


                    int randomIndex = _random.Next(_deck.DeckList.Count);
                    ICard cardToDeal = SerializeCardObj(_deck.DeckList[randomIndex]);
                    _deck.DeckList.RemoveAt(randomIndex);
                    player.RecieveCard(cardToDeal);

                    if (player.CheckIfWon()) GameIsRunning = false;
                    return cardToDeal;

                } else
                {
                    return new NullCard();
                }
            }
        }


        public ICard DealSuitedCard()
        {
            lock (_deckLock)
            {
                ICard cardToDeal = new NullCard();

                if (_deck.DeckList.Count < 5)
                {
                    moveDiscardDeckToNormalDeck();
                }

                bool suitedCardDraws = false;

                while (!suitedCardDraws)
                {
                    int index = _random.Next(_deck.DeckList.Count);
                    ICard drawnCard = _deck.DeckList[index];

                    if (drawnCard.GetType() == typeof(SuitedCard))
                    {
                        cardToDeal = SerializeCardObj(drawnCard);
                        _deck.DeckList.RemoveAt(index);
                        suitedCardDraws = true;
                        return cardToDeal;
                    }
                }
                return cardToDeal;
            }

        }

        private ICard SerializeCardObj(ICard card)
        {
            string cardToJson = JsonConvert.SerializeObject(card);
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

        public void ReceiveDiscardedCard(ICard card)
        {
            var newCardObj = SerializeCardObj(card);
            _discard.Add(newCardObj);
        }

        public void moveDiscardDeckToNormalDeck()
        {
            if(_discard.Count > 0) 
            { 
                for (int i = 0; i < _discard.Count; i++)
                {
                    ICard cardToMove = SerializeCardObj(_discard[i]);
                    _deck.DeckList.Add(cardToMove);
                    _discard.RemoveAt(i);
                }
            }
            Console.WriteLine("Dealer moved discard stack to deck");
        }

        


    }
}
