using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    interface IDrawCards
    {

        #region Card Size Properties
        // Indexs for changing the string shown on the card. If the card is resized these will need to be changed for layout purposes.
        static int[] TopRightStartIndex = { 3, 12 };
        static int[] BottomLeftStartIndex = { 11, 3 };
        static int[] SymbolIndex = { 7, 9 };

        //TODO: If my card length is 11 and my goal is two, how can I calculate this on a changing length value?
        // I think I need to start by getting a few different scenerios of what all indexs/sizes are and then creating a formula to get the desired outcome in all situations
        // think how functions are taught in math in grade school

        // Width and Length of the card. Must change indexs above if these are changed.
        static int CardWidth = 18;
        static int CardLength = 13;

        #endregion

        #region Card Type Properties
        /// <summary>
        /// String that should be displayed on the card. Example: "A ♠ "
        /// </summary>
        public string StringForCard { get; set; }
        /// <summary>
        /// String representing the Suit of the card.
        /// </summary>
        public string Suit { get; set; }
        #endregion




        // enum used to define what type of line we will create for the card.
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
            if(stringToInsert.Contains("10"))
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
                else if(currentChar == startIndex)
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
            switch(lineToDraw)
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

        /// <summary>
        /// Return an array of strings representing the card provided. stringForCard should be a 4 digit string such as "9 ♠ ". with the suit "♠"
        /// </summary>
        /// <param name="stringForCard"></param>
        /// <param name="suitForCard"></param>
        /// <returns></returns>
        public static string[] CardForConsole(string stringForCard, string suitForCard)
        {
            var arrayToReturn = new string[CardLength + 1];
            // cycle through each array
            for (int cardLine = 0; cardLine <= CardLength; cardLine++)
            {
                // add to stringToReturn based on the current index
                switch(cardLine)
                {
                    case int line when line == 0:
                        arrayToReturn[cardLine] += LineForCard(CardWidth, CardLine.Top, stringForCard, suitForCard); 
                            break;
                    case int line when line == TopRightStartIndex[0]:
                        arrayToReturn[cardLine] += LineForCard(CardWidth, CardLine.TopRightNumber, stringForCard, suitForCard);
                        break;
                    case int line when line == BottomLeftStartIndex[0]:
                        arrayToReturn[cardLine] += LineForCard(CardWidth, CardLine.BottomLeftNumber, stringForCard, suitForCard);
                        break;
                    case int line when line == SymbolIndex[0]:
                        arrayToReturn[cardLine] += LineForCard(CardWidth, CardLine.Symbol, stringForCard, suitForCard);
                        break;
                    case int line when line == CardLength:
                        arrayToReturn[cardLine] += LineForCard(CardWidth, CardLine.Bottom, stringForCard, suitForCard);
                        break;
                    default:
                        arrayToReturn[cardLine] += LineForCard(CardWidth, CardLine.EmptySpace, stringForCard, suitForCard);
                        break;
                }
            }
            return arrayToReturn;

        }

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

    }
}
