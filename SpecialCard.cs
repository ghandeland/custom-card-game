using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class SpecialCard : ICard
    {
        public SpecialCardType Type { get; set; }

        public SpecialCard(SpecialCardType type)
        {
            Type = type;
        }

        public SpecialCard() { }

        public string getCardInfo()
        {
            return (Type.ToString());
        }
    }

    enum SpecialCardType
    {
        Bomb,
        Vulture,
        Quarantine,
        Joker
    }
}
