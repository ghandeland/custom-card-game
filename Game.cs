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
        public event EventHandler GameWon;

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
                throw new IndexOutOfRangeException("Player amount ranges from 2-4 players");
            }
        }

        public void SetupGame()
        { 
            foreach (Player player in _players)
            {
                player.drawStartingCards(4);
                player.WinEvent += EndGame;
            }
            
        }

        private void EndGame(Player sender, EventArgs e)
        {
            Console.WriteLine($"Player{sender.Id} won the game with following hand:");
            sender.PrintCurrentHand();
            _dealer.GameIsRunning = false;
            Console.WriteLine($"Player{sender.Id} won the game with following hand:");
            
        }

        public void StartGame()
        {
            SetupGame();
            foreach (Player player in _players)
            {
                player.Start();
            }

        }
    }
}
