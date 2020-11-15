using System;
using System.Collections.Generic;
using System.Text;

namespace Kristiania.PG3302_1.CustomCardGame.CardStrategy
{
    abstract class CardStrategy
    {
        protected ICard Card;

        public CardStrategy(ICard card)
        {
            this.Card = card;
        }

        public abstract void HandleCard(Player player);

    }
}