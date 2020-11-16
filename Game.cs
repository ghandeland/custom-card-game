using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Text;
using System.Threading;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class Game
    {
        private bool GameIsWon { get; set; }
        private Dealer _dealer;
        private List<Player> _players;
        private Deck _deck;

        public Game(int playerAmount)
        {
            _deck = new Deck();
            _dealer = new Dealer(_deck);
            _players = new List<Player>();
            if (playerAmount > 1 && playerAmount < 5)
            {
                for (int i = 0; i < playerAmount; i++)
                {
                    _players.Add(new Player(i+1, _dealer));
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }



        public void StartGame()
        {
            
        }
    }
}
