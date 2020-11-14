using System;
using System.Collections.Generic;
using System.Text;
using Kristiania.PG3302_1.CustomCardGame.CardStrategy;

namespace Kristiania.PG3302_1.CustomCardGame.specialCardStrategy
{
    class JokerStrategy : CardStrategy.CardStrategy
    {
        public JokerStrategy(Card card) : base(card)
        {
            Card = card;
        }

        public override void HandleCard(Player player)
        {
            player.Hand.Add(Card);
            Console.WriteLine($"Player{player.Id} drew JOKER {Card.getCardInfo()}");
        }
    }
}
