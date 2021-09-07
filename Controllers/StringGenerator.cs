using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public static class StringGenerator
    {

        /// <summary>
        /// Return a string created with the provided string inserted at the specified 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="firstAndLastChar"></param>
        /// <param name="middleChar"></param>
        /// <returns></returns>
        public static string FirstMiddleFirst(int width, char firstAndLastChar, char middleChar)
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
        /// Create a string using the firstAndLast and middleChar provided, and then insert the provided string at the startIndex given.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="firstAndLastChar"></param>
        /// <param name="middleChar"></param>
        /// <returns></returns>
        public static string FirstMidInsertMidFirst(int width, char firstAndLastChar, char middleChar, int startIndex, string stringToInsert)
        {
            var stringToReturn = string.Empty;
            //TODO: Break the below if statement out and back into card class. 
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



    }
}
