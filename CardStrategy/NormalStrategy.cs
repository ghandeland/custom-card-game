using System;
using System.Collections.Generic;
using System.Text;

namespace Kristiania.PG3302_1.CustomCardGame.CardStrategy
{
    class NormalStrategy : CardStrategy
    {
        public NormalStrategy(Card card) : base(card)
        {
            Card = card;
        }

        public override void HandleCard(Player player)
        {
            player.Hand.Add(Card);
            Console.WriteLine($"Player{player.Id} drew card {Card.getCardInfo()}");
        }
    }
}
