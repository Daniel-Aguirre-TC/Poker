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



        //TODO: Should I break card off into seperate classes, ie Ace, Two, Three etc then maybe I can define just the Suit in my constructor?
        //public static List<Card> baseDeck = new List<Card>()
        //{
        //    new Card("Aces of Spades", "A ♠", "♠", 1),
        //    new Card("Two of Spades", "2 ♠", "♠", 2),
        //    new Card("Three of Spades", "3 ♠", "♠", 3),
        //    new Card("Four of Spades", "4 ♠", "♠", 4),
        //    new Card("Five of Spades", "5 ♠", "♠", 5),
        //    new Card("Six of Spades", "6 ♠", "♠", 6),
        //    new Card("Seven of Spades", "7 ♠", "♠", 7),
        //    new Card("Eight of Spades", "8 ♠", "♠", 8),
        //    new Card("Nine of Spades", "9 ♠", "♠", 9),
        //    new Card("Ten of Spades", "10 ♠", "♠", 10),
        //    new Card("Jack of Spades", "J ♠", "♠", 10),
        //    new Card("Queen of Spades", "Q ♠", "♠", 10),
        //    new Card("King of Spades", "K ♠", "♠", 10),

        //    new Card("Aces of Clubs", "A ♣", "♣", 1),
        //    new Card("Two of Clubs", "2 ♣", "♣", 2),
        //    new Card("Three of Clubs", "3 ♣", "♣", 3),
        //    new Card("Four of Clubs", "4 ♣", "♣", 4),
        //    new Card("Five of Clubs", "5 ♣", "♣", 5),
        //    new Card("Six of Clubs", "6 ♣", "♣", 6),
        //    new Card("Seven of Clubs", "7 ♣", "♣", 7),
        //    new Card("Eight of Clubs", "8 ♣", "♣", 8),
        //    new Card("Nine of Clubs", "9 ♣", "♣", 9),
        //    new Card("Ten of Clubs", "10 ♣", "♣", 10),
        //    new Card("Jack of Clubs", "J ♣", "♣", 10),
        //    new Card("Queen of Clubs", "Q ♣", "♣", 10),
        //    new Card("King of Clubs", "K ♣", "♣", 10),

        //    new Card("Aces of Hearts", "A ♥", "♥", 1),
        //    new Card("Two of Hearts", "2 ♥", "♥", 2),
        //    new Card("Three of Hearts", "3 ♥", "♥", 3),
        //    new Card("Four of Hearts", "4 ♥ ", "♥", 4),
        //    new Card("Five of Hearts", "5 ♥ ", "♥", 5),
        //    new Card("Six of Hearts", "6 ♥ ", "♥", 6),
        //    new Card("Seven of Hearts", "7 ♥ ", "♥", 7),
        //    new Card("Eight of Hearts", "8 ♥ ", "♥", 8),
        //    new Card("Nine of Hearts", "9 ♥ ", "♥", 9),
        //    new Card("Ten of Hearts", "10 ♥", "♥", 10),
        //    new Card("Jack of Hearts", "J ♥ ", "♥", 10),
        //    new Card("Queen of Hearts", "Q ♥ ", "♥", 10),
        //    new Card("King of Hearts", "K ♥ ", "♥", 10),

        //    new Card("Aces of Diamonds", "A ♦ ", "♦", 1),
        //    new Card("Two of Diamonds", "2 ♦ ", "♦", 2),
        //    new Card("Three of Diamonds", "3 ♦ ", "♦", 3),
        //    new Card("Four of Diamonds", "4 ♦ ", "♦", 4),
        //    new Card("Five of Diamonds", "5 ♦ ", "♦", 5),
        //    new Card("Six of Diamonds", "6 ♦ ", "♦", 6),
        //    new Card("Seven of Diamonds", "7 ♦ ", "♦", 7),
        //    new Card("Eight of Diamonds", "8 ♦ ", "♦", 8),
        //    new Card("Nine of Diamonds", "9 ♦ ", "♦", 9),
        //    new Card("Ten of Diamonds", "10 ♦", "♦", 10),
        //    new Card("Jack of Diamonds", "J ♦ ", "♦", 10),
        //    new Card("Queen of Diamonds", "Q ♦ ", "♦", 10),
        //    new Card("King of Diamonds", "K ♦ ", "♦", 10),
        //};

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
