using System;
using System.Collections.Generic;
using System.Text;
using Kristiania.PG3302_1.CustomCardGame.CardStrategy;

namespace Kristiania.PG3302_1.CustomCardGame.specialCardStrategy
{
    class VultureStrategy : CardStrategy.CardStrategy
    {
        public VultureStrategy(SpecialCard card) : base(card)
        {
            Card = card;
        }

        public override void HandleCard(Player player)
        {
            player.Hand.Add(Card);
            Console.WriteLine($"Player{player.Id} drew VULTURE {Card.GetCardInfo()} and can draw another card!");
            
            ICard card = player.DrawCard();
            player.Hand.Add(card);
            Console.WriteLine($"Player{player.Id} drew card {card.GetCardInfo()}");
            player.DiscardCard(player.GetCardToDiscard());
        }
    }
}
