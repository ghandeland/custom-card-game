using System;
using System.Collections.Generic;
using System.Text;

namespace Kristiania.PG3302_1.CustomCardGame
{
    public interface IPlayer
    {
        void Start();
        void Play();
        ICard DrawCard();
        void PrintCurrentHand();
        void DrawStartingCards(int players);
    }
}
