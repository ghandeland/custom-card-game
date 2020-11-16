using System;
using System.Collections.Generic;
using System.Text;
using Kristiania.PG3302_1.CustomCardGame.CardStrategy;

namespace Kristiania.PG3302_1.CustomCardGame.specialCardStrategy
{
    class BombStrategy : CardStrategy.CardStrategy
    {
        public BombStrategy(SpecialCard card) : base(card)
        {
            Card = card;
        }

        public override void HandleCard(Player player)
        {
            player.Hand.Add(Card);
            Console.WriteLine($"Player{player.Id} drew {Card.getCardInfo()} and has to discard all cards!");

            for (int i = player.Hand.Count - 1; i >= 0; i--)
            {
                player.DiscardCard(player.Hand[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                ICard card = player.DrawCard();
                player.Hand.Add(card);
                Console.WriteLine($"Player{player.Id} drew card {card.getCardInfo()}");
            }
        }
    }
}
