using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker
{
    public class Card : IDrawCards, IWriteToTheConsole
    {
        public enum CardSuit { Spades, Clubs, Hearts, Diamonds}
        public enum CardName { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

        public int _Value { get; set; }
        public string _Name { get; set; }
        public string _StringForCard { get; set; }
        public string _Suit { get; set; }

        public Card(CardName Name, CardSuit Suit )
        {
            _Name = ConvertName(Name, Suit);
            _Suit = ConvertSymbol(Suit);
            _Value = ConvertValue(Name);
            _StringForCard = ConvertStringForCard(Name, Suit);
        }
        /// <summary>
        /// Return string to display on card based on CardName and CardSuit provided. Such as "A ♠"
        /// </summary>
        /// <param name="cardName"></param>
        /// <param name="cardSuit"></param>
        /// <returns></returns>
        static string ConvertStringForCard(CardName cardName, CardSuit cardSuit)
        {
            var stringForCard = string.Empty;
            switch (cardName)
            {
                case CardName.Ace:
                    stringForCard += "A ";
                    break;
                case CardName.Two:
                    stringForCard += "2 ";
                    break;
                case CardName.Three:
                    stringForCard += "3 ";
                    break;
                case CardName.Four:
                    stringForCard += "4 ";
                    break;
                case CardName.Five:
                    stringForCard += "5 ";
                    break;
                case CardName.Six:
                    stringForCard += "6 ";
                    break;
                case CardName.Seven:
                    stringForCard += "7 ";
                    break;
                case CardName.Eight:
                    stringForCard += "8 ";
                    break;
                case CardName.Nine:
                    stringForCard += "9 ";
                    break;
                case CardName.Ten:
                    stringForCard += "10 ";
                    break;
                case CardName.Jack:
                    stringForCard += "J ";
                    break;
                case CardName.Queen:
                    stringForCard += "Q ";
                    break;
                case CardName.King:
                    stringForCard += "K ";
                    break;
            }
            stringForCard += ConvertSymbol(cardSuit);
            return stringForCard;
        }
        /// <summary>
        /// Return an int based on CardName provided. Ace is 11 by default.
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        static int ConvertValue (CardName cardName)
        {
            switch (cardName)
            {
                case CardName.Ace:
                    return 11;
                case CardName.Two:
                    return 2;
                case CardName.Three:
                    return 3;
                case CardName.Four:
                    return 4;
                case CardName.Five:
                    return 5;
                case CardName.Six:
                    return 6;
                case CardName.Seven:
                    return 7;
                case CardName.Eight:
                    return 8;
                case CardName.Nine:
                    return 9;
                case CardName.Ten:
                case CardName.Jack:
                case CardName.Queen:
                case CardName.King:
                    return 10;
                default:
                    //TODO: How to handle this default that should never happen
                    return 0;
            }
        }
        /// <summary>
        /// Return "♠", "♣", "♥", or "♦" Based on CardSuit provided. 
        /// </summary>
        /// <param name="cardsuit"></param>
        /// <returns></returns>
        static string ConvertSymbol(CardSuit cardSuit)
        {
            switch (cardSuit)
            {
                case CardSuit.Spades:
                    return "♠";
                case CardSuit.Clubs:
                    return "♣";
                case CardSuit.Hearts:
                    return "♥";
                case CardSuit.Diamonds:
                    return "♦";
                default:
                    return null;
            }
        }
        /// <summary>
        /// Return name of card such as "Ace of Spades" Based on CardName and CardSuit provided
        /// </summary>
        /// <param name="name"></param>
        /// <param name="suit"></param>
        /// <returns></returns>
        static string ConvertName(CardName cardName, CardSuit cardSuit)
        {
            return $"{cardName} of {cardSuit}";
        }

        public string[] ReturnCardArray()
        {
            return IDrawCards.CardForConsole(_StringForCard, _Suit);
        }

        public void ReceivedCardScreen()
        {
            string a = _Name.Contains("Eight") || _Name.Contains("Ace") ? "an" : "a";
            // message to display under the card.
            var message = new string[]
            {
                "", "", $"You were dealt {a} {_Name}!", "", "Press any key to continue. "
            };
            var cardAndMessage = ReturnCardArray().Concat(message).ToArray();
            // Print the card centered to the screen with message above concated below it.
            IWriteToTheConsole.PrintCenteredVerticalHorizontal(cardAndMessage, true);
            // Clear the screen after key press.
            IWriteToTheConsole.ClearAfterKeyPress();
        }
    }
}
