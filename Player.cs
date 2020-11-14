using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Threading;
using Newtonsoft.Json;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class Player
    {
        public int Id { get; set; }
        public List<Card> Hand { get; set; }
        private Thread _playerThread;
        private Dealer _dealer;

        public Player(int id, Dealer dealer)
        {
            Id = id;
            _playerThread = new Thread(DrawCard);
            _dealer = dealer;
            Hand = new List<Card>();
        }

        private void DrawCard()
        {
            while (true)
            {
                string jsonCard = _dealer.DealCard();
                Thread.Sleep(1000);
                Card card = Card.DeserializeCard(jsonCard);
                Hand.Add(card);
                Console.WriteLine($"Player{Id} drew card {card.getCardInfo()}");
            }
        }

        public void Start()
        {
            _playerThread.Start();
        }




    }

}
