using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker
{
    public class Card
    {

        #region Card Type Properties

        public enum CardSuit { Spades, Clubs, Hearts, Diamonds}
        public enum CardName { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

        public int Value { get; set; }
        public string Name { get; set; }
        public string StringForCard { get; set; }
        public string Suit { get; set; }

        #endregion

        #region Static Card Size Properties
        // Indexs for changing the string shown on the card. If the card is resized these will need to be changed for layout purposes.
        static int[] TopRightStartIndex = { 3, 13 };
        static int[] BottomLeftStartIndex = { 11, 3 };
        static int[] SymbolIndex = { 7, 9 };

        //TODO: If my card length is 11 and my goal is two, how can I calculate this on a changing length value?
        // I think I need to start by getting a few different scenerios of what all indexs/sizes are and then creating a formula to get the desired outcome in all situations
        // think how functions are taught in math in grade school

        // Width and Length of the card. Must change indexs above if these are changed.
        static int CardWidth = 18;
        static int CardLength = 13;

        #endregion

        #region Constructor

        /// <summary>
        /// Based on provided name and suit will create a new card.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="suit"></param>
        public Card(CardName name, CardSuit suit)
        {
            Name = ConvertName(name, suit);
            Suit = ConvertSymbol(suit);
            Value = ConvertValue(name);
            StringForCard = ConvertStringForCard(name, suit);
        }

        #endregion

        #region Helpers for Card Constructor

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
        static int ConvertValue(CardName cardName)
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

        #endregion

        #region Card string[] Creation

        /// <summary>
        /// CardLine enum is used for creating the array representing the card in the console. This will tell a switch statement what type of line to create, as it is created one line at a time.
        /// </summary>
        enum CardLine { Top, EmptySpace, TopRightNumber, Symbol, BottomLeftNumber, Bottom }

        /// <summary>
        /// Return a string created with the provided string inserted at the specified 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="firstAndLastChar"></param>
        /// <param name="middleChar"></param>
        /// <returns></returns>
        static string CreateLine(int width, char firstAndLastChar, char middleChar)
        {
            var stringToReturn = string.Empty;

            // go through a loop as long as we are have not surpassed width.
            for (int currentChar = 0; currentChar <= width; currentChar++)
            {
                // if we are on first or last char, then add the provided firstAndLastChar
                if (currentChar == 0 || currentChar == width)
                {
                    stringToReturn += firstAndLastChar.ToString();
                }
                // else add the middleChar provided
                else
                {
                    stringToReturn += middleChar.ToString();
                }
            }
            return stringToReturn;
        }

        /// <summary>
        /// Return a string created based on the length, and provided first and last char.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="firstAndLastChar"></param>
        /// <param name="middleChar"></param>
        /// <returns></returns>
        static string CreateLine(int width, char firstAndLastChar, char middleChar, int startIndex, string stringToInsert)
        {
            var stringToReturn = string.Empty;

            // move start index forward one if the line we're creating is a ten, to keep the symbol from moving backwards for a two digit number.
            if (stringToInsert.Contains("10"))
            {
                startIndex--;
            }

            // go through a loop as long as we are have not surpassed width.
            for (int currentChar = 0; currentChar <= width; currentChar++)
            {
                // if we are on first or last char, then add the provided firstAndLastChar
                if (currentChar == 0 || currentChar == width)
                {
                    stringToReturn += firstAndLastChar.ToString();
                }
                else if (currentChar == startIndex)
                {
                    stringToReturn += stringToInsert;
                    currentChar += stringToInsert.Length - 1;
                }
                // else add the middleChar provided
                else
                {
                    stringToReturn += middleChar.ToString();
                }
            }
            return stringToReturn;
        }

        /// <summary>
        /// Draw a line to return in CardForConsole based on the CardWidth value.
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        static string LineForCard(int width, CardLine lineToDraw, string cardDrawing, string cardSuit)
        {
            switch (lineToDraw)
            {
                case CardLine.Top:
                    return CreateLine(width, ' ', '_');
                case CardLine.EmptySpace:
                    return CreateLine(width, '|', ' ');
                case CardLine.TopRightNumber:
                    return CreateLine(width, '|', ' ', TopRightStartIndex[1], cardDrawing);
                case CardLine.Symbol:
                    return CreateLine(width, '|', ' ', SymbolIndex[1], cardSuit);
                case CardLine.BottomLeftNumber:
                    return CreateLine(width, '|', ' ', BottomLeftStartIndex[1], cardDrawing);
                case CardLine.Bottom:
                    return CreateLine(width, '|', '_');
                default:
                    //TODO: Ask whit about how I should handle this... Debug.Log? ThrowError? This scenerio should never actually happen based on enum being passed.
                    return null;
            }
        }

        #endregion

        #region Card string[] Distribution
        
        public string[] CardStringArray { get { return CardForConsole(this); } }

        /// <summary>
        /// Return an array of strings representing the card provided. stringForCard should be a 4 digit string such as "9 ♠ ". with the suit "♠"
        /// </summary>
        /// <param name="stringForCard"></param>
        /// <param name="suitForCard"></param>
        /// <returns></returns>
        public static string[] CardForConsole(Card cardToDisplay)
        {
           return CardForConsole(cardToDisplay.StringForCard, cardToDisplay.Suit);
        }
       
        /// <summary>
        /// Create a card with the input strings. Created with the intention of creating "???" cards to hide the numbers from players. However, other strings could be passed in.
        /// </summary>
        /// <param name="cornerStrings"></param>
        /// <param name="centerString"></param>
        /// <returns></returns>
        public static string[] CardForConsole(string cornerStrings, string centerString)
        {
            var arrayToReturn = new string[CardLength + 1];
            // cycle through each array
            for (int cardLine = 0; cardLine <= CardLength; cardLine++)
            {
                // add to stringToReturn based on the current index
                switch (cardLine)
                {
                    case int line when line == 0:
                        arrayToReturn[cardLine] += LineForCard(CardWidth, CardLine.Top, cornerStrings, centerString);
                        break;
                    case int line when line == TopRightStartIndex[0]:
                        arrayToReturn[cardLine] += LineForCard(CardWidth, CardLine.TopRightNumber, cornerStrings, centerString);
                        break;
                    case int line when line == BottomLeftStartIndex[0]:
                        arrayToReturn[cardLine] += LineForCard(CardWidth, CardLine.BottomLeftNumber, cornerStrings, centerString);
                        break;
                    case int line when line == SymbolIndex[0]:
                        arrayToReturn[cardLine] += LineForCard(CardWidth, CardLine.Symbol, cornerStrings, centerString);
                        break;
                    case int line when line == CardLength:
                        arrayToReturn[cardLine] += LineForCard(CardWidth, CardLine.Bottom, cornerStrings, centerString);
                        break;
                    default:
                        arrayToReturn[cardLine] += LineForCard(CardWidth, CardLine.EmptySpace, cornerStrings, centerString);
                        break;
                }
            }
            return arrayToReturn;
        }


        /// <summary>
        /// Return an array of strings representing the cards in the provided hand.
        /// </summary>
        /// <param name="handToDraw"></param>
        /// <returns></returns>
        public static string[] HandForConsole(List<Card> handToDraw)
        {
            // string to return at the end
            string[] handToReturn = new string[CardLength + 1];
            // loop through each card in hand to draw
            foreach (var card in handToDraw)
            {
                // the array for the card we are adding to the hand
                var cardToAdd = CardForConsole(card.StringForCard, card.Suit);

                //TODO: double check the cardlength + 1 is right
                for (int cardLine = 0; cardLine < CardLength + 1; cardLine++)
                {
                    handToReturn[cardLine] += " " + cardToAdd[cardLine];
                }
            }
            return handToReturn;

        }

        #endregion

    }
}
