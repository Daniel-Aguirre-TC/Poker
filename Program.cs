using System;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {

            foreach (var card in Deck.baseDeck)
            {
                card.ReceivedCardScreen();
            }
        }
    }
}
