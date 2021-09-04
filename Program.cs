using System;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 60);

            foreach (var card in Deck.baseDeck)
            {
                card.ReceivedCardScreen();
            }
        }
    }
}
