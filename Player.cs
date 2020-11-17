using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using Kristiania.PG3302_1.CustomCardGame.CardStrategy;
using Newtonsoft.Json;

namespace Kristiania.PG3302_1.CustomCardGame
{
    public class Player : IPlayer
    {
        public int Id { get; set; }
        public List<ICard> Hand { get; set; }
        private Thread _playerThread;
        private Dealer _dealer;
        private bool _run;
        public bool Quarantine { get; set; }

        public delegate void WinEventDelegate(Player source, EventArgs args);
        public event WinEventDelegate WinEvent;


        public Player(int id, Dealer dealer)
        {
            Id = id;
            _playerThread = new Thread(Play);
            _dealer = dealer;
            Hand = new List<ICard>();
            Quarantine = false;
        }

        public void Play()
        {
            while (_dealer.GameIsRunning)
            {
                
                if(!Quarantine) {

                    ICard card = DrawCard();

                    if(card.GetType() != typeof(NullCard))
                    {
                        Thread.Sleep(300);

                        CardHandler cardHandler = StratFactory.CreateHandler(card);
                        cardHandler.Handle(this);


                        if (HasFourOfTheSameSuit())
                        {
                            OnFourOfTheSameSuit();
                        }
                    }
                    
                    

                } else
                {
                        Quarantine = false;
                        Console.WriteLine($"Player{Id} had to skip a turn:(");
                }


                
            }
        }

        private void OnFourOfTheSameSuit()
        {
            WinEvent?.Invoke(this, EventArgs.Empty);
        }

        public void DiscardCard(ICard card)
        {
            int index = -1;
            for (int i = 0; i < Hand.Count; i++)
            {
                if (card.Equals(Hand[i]))
                {
                    index = i;
                }
            }
            if(index > -1)
            {
                ICard beforeDiscard = Hand[index];
                _dealer.ReceiveDiscardedCard(beforeDiscard);
                Console.WriteLine($"Player{Id} discarded {beforeDiscard.GetCardInfo()}");
                Hand.RemoveAt(index);
            } 
            
       
        }

        private bool HasFourOfTheSameSuit()
        {
            var SuitCount = new Dictionary<CardSuit, int>();
            bool hasJoker = false;

            foreach (ICard card in Hand)
            {
                if (card.GetType() == typeof(SuitedCard))
                {
                    SuitedCard suited = (SuitedCard) card;

                    if (SuitCount.ContainsKey(suited.Suit))
                        SuitCount[suited.Suit]++;
                    else
                        SuitCount[suited.Suit] = 1;
                }
                else
                {
                    SpecialCard special = (SpecialCard) card;
                    if (special.Type == SpecialCardType.Joker) hasJoker = true;
                }
            }

            List<CardSuit> keys = new List<CardSuit>(SuitCount.Keys);
            if (hasJoker)
            {
                foreach (var key in keys)
                {
                    SuitCount[key]++;
                }
            }

            foreach (var pair in SuitCount) {
                if (pair.Value > 3)
                {
                    return true;
                }
            }

            return false;
        }

        public ICard GetCardToDiscard()
        {
            ICard discardCard = new NullCard();

            var SuitCount = new Dictionary<CardSuit, int>();

            foreach (ICard card in Hand)
            {
                if (card.GetType() == typeof(SuitedCard))
                {
                    SuitedCard suited = (SuitedCard)card;

                    if (SuitCount.ContainsKey(suited.Suit))
                        SuitCount[suited.Suit]++;
                    else
                        SuitCount[suited.Suit] = 1;
                } else
                {
                    SpecialCard special = (SpecialCard) card;
                    if(special.Type == SpecialCardType.Bomb
                        || special.Type == SpecialCardType.Quarantine)
                    {
                        return special;
                    }

                }
            }

            List<CardSuit> keys = new List<CardSuit>(SuitCount.Keys);
            int lowestCount = 7;
            CardSuit lowestSuit = CardSuit.Spades;
            
            foreach (CardSuit key in keys)
            {
                if (SuitCount[key] <= lowestCount)
                {
                    lowestCount = SuitCount[key];
                    lowestSuit = key;
                }
            }

            foreach(ICard card in Hand)
            {
                if(card.GetType() == typeof(SuitedCard))
                {
                    SuitedCard sCard = (SuitedCard) card;
                    if(sCard.Suit.Equals(lowestSuit))
                    {
                        discardCard = card;
                    }
                }
                
            }

   

            return discardCard;
        }

        public ICard DrawCard()
        {
            return _dealer.DealCard();
        }

        public void Start()
        {
            _playerThread.Start();
        }

        /*public void Stop()
        {
            _playerThread = null;
            _run = !_run;
        }*/

        public void DrawStartingCards(int cardAmount)
        {
            
            for(int i = 0; i < cardAmount; i++)
            {
                ICard card = _dealer.DealSuitedCard();
                Hand.Add(card);
            }
            PrintCurrentHand();
           
        }

        public void PrintCurrentHand()
        {

            string startString = $"Player{Id} hand: |";
            foreach (ICard card in Hand)
            {
                startString += $" {card.GetCardInfo()} |";
            }
            Console.WriteLine(startString);
        }

      
    }
}
