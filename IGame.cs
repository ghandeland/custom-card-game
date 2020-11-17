using System;
using System.Collections.Generic;
using System.Text;

namespace Kristiania.PG3302_1.CustomCardGame
{
    public interface IGame
    {
        void SetupGame();
        void EndGame();
        void StartGame();
    }
}
