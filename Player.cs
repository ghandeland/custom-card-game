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
    class Player
    {
        public int Id { get; set; }
        public List<ICard> Hand { get; set; }
        private Thread _playerThread;
        private Dealer _dealer;
        public bool Quarantine { get; set; }

        public Player(int id, Dealer dealer)
        {
            Id = id;
            _playerThread = new Thread(DrawCard);
            _dealer = dealer;
            Hand = new List<ICard>();
            Quarantine = false;
        }

        private void DrawCard()
        {
            while (true)
            {
                ICard card = _dealer.DealCard();

                if (Quarantine)
                {
                    Quarantine = false;
                    Console.WriteLine($"Player{Id} had to skip a turn:(");
                    return;
                }

                Thread.Sleep(300);

                CardHandler cardHandler = StratFactory.CreateHandler(card);
                cardHandler.Handle(this);
                if (HasFourOfTheSameSuit())
                {
                    Console.WriteLine("*****************************");
                }

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

        public void Start()
        {
            _playerThread.Start();
        }

    }
}
