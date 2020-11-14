using System;
using System.Collections.Generic;
using System.Text;

namespace Kristiania.PG3302_1.CustomCardGame.CardStrategy
{
    class CardHandler
    {
        private CardStrategy _cardStrategy;

        public CardHandler(CardStrategy cardStrategy)
        {
            _cardStrategy = cardStrategy;
        }

        public void Handle(Player player)
        {
            _cardStrategy.HandleCard(player);
        }

    }
}
