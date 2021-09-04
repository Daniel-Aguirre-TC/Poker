using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Deck
    {

        public static List<Card> baseDeck = new List<Card>();
        
        // static constructor to instantiate the static baseDeck.
        static Deck()
        {
            // add each possible card combination to deck based on Card.CardSuit and Card.CardName
            InstantiateDeck();
        }

        /// <summary>
        /// Foreach Card.CardSuit, we will add a new card to the baseDeck for each Card.CardName
        /// </summary>
        static void InstantiateDeck()
        {
            foreach (Card.CardSuit suit in Enum.GetValues(typeof(Card.CardSuit)))
            {
                foreach (Card.CardName card in Enum.GetValues(typeof(Card.CardName)))
                {
                    baseDeck.Add(new Card(card, suit));
                }

            }
        }

        static string[] deckConsoleImage = new string[]
        {
                    " _____________ ",
                    "|             |",
                    "|             |",
                    "|  Daniel's   |",
                    "|     Black   |",
                    "|       Jack  |",
                    "|             |",
                    "|   ♠ ♣ ♥ ♦   |",
                    "|   ~ Deck ~  |",
                    "|   ♠ ♣ ♥ ♦   |",
                    "|             |",
                    "|_____________|",
        };






    }
}
