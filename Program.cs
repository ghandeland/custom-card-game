using System;

namespace Kristiania.PG3302_1.CustomCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Deck deck = new Deck();
            Player player1 = new Player(1, null);
            Console.WriteLine("Amounts of cards in deck " + deck.DeckList.Count);
            int rndCardIndex = random.Next(deck.DeckList.Count);
            Card rndCard = deck.DeckList[rndCardIndex];
            player1.Hand.Add(rndCard);
            Console.WriteLine("Amounts of cards in deck " + deck.DeckList.Count);
            Console.WriteLine("Player1 draws a: ");
            player1.Hand[0].PrintCardInfo();
            deck.DeckList.RemoveAt(rndCardIndex);
        }
    }
}
