using System;
using System.Collections.Generic;
using System.Text;
using Kristiania.PG3302_1.CustomCardGame.specialCardStrategy;

namespace Kristiania.PG3302_1.CustomCardGame.CardStrategy
{
    class StratFactory
    {
        public static CardHandler CreateHandler(ICard card)
        {
            if (card.GetType() == typeof(SuitedCard))
            {
                SuitedCard suitedCard = (SuitedCard) card;
                return new CardHandler(new SuitedStrategy(card));
            }
            else
            {
                SpecialCard specialCard = (SpecialCard) card;
                switch(specialCard.Type) {
                    case SpecialCardType.Quarantine:
                        return new CardHandler(new QuarantineStrategy(specialCard));
                    case SpecialCardType.Joker:
                        return new CardHandler(new JokerStrategy(specialCard));
                    case SpecialCardType.Vulture:
                        return new CardHandler(new VultureStrategy(specialCard));
                    default:
                        return new CardHandler(new BombStrategy(specialCard));
                }
            }

            
        }
    }
}
