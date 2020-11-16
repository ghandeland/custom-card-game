using System;
using System.Collections.Generic;
using System.Text;
using Kristiania.PG3302_1.CustomCardGame.CardStrategy;

namespace Kristiania.PG3302_1.CustomCardGame.specialCardStrategy
{
    class QuarantineStrategy : CardStrategy.CardStrategy
    {
        public QuarantineStrategy(SpecialCard card) : base(card)
        {
            Card = card;
        }

        public override void HandleCard(Player player)
        {
            player.Hand.Add(Card);
            player.Quarantine = true;
            Console.WriteLine($"Player{player.Id} drew {Card.getCardInfo()} and has to skip a turn!");
            
        }
    }
}
