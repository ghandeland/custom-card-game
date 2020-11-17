using System;
using System.Collections.Generic;
using System.Text;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class NullCard : ICard
    {
        public string GetCardInfo() 
        {
            return "NullCard";
        }
    }
}
