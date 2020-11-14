using System;
using System.Collections.Generic;
using System.Text;
using Kristiania.PG3302_1.CustomCardGame.specialCardStrategy;

namespace Kristiania.PG3302_1.CustomCardGame.CardStrategy
{
    class StratFactory
    {
        public static CardHandler CreateHandler(Card card)
        {
            switch (card.Type)
            {
                case CardType.Bomb:
                    return new CardHandler(new BombStrategy(card));
                case CardType.Quarantine:
                    return new CardHandler(new QuarantineStrategy(card));
                case CardType.Joker:
                    return new CardHandler(new JokerStrategy(card));
                case CardType.Vulture:
                    return new CardHandler(new VultureStrategy(card));
                default:
                    return new CardHandler(new NormalStrategy(card));
            }
        }
    }
}
