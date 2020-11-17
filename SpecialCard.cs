using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Kristiania.PG3302_1.CustomCardGame
{
    public class SpecialCard : ICard
    {
        public SpecialCardType Type { get; set; }

        public SpecialCard(SpecialCardType type)
        {
            Type = type;
        }

        public SpecialCard() { }

        public string GetCardInfo()
        {
            return (Type.ToString());
        }
    }

    public enum SpecialCardType
    {
        Bomb,
        Vulture,
        Quarantine,
        Joker
    }
}
