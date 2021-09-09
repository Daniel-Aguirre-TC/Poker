using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Poker.Cards;

namespace Poker
{
    public class StandardCard : Card
    {

        #region Card Type Properties

        //TODO: Split StandardCard into classes for each card Ace - King ?
        public enum CardSuit { Spades, Clubs, Hearts, Diamonds }
        public enum CardName { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }
        public string Suit { get; set; }

        public int Value { get; set; }
        public string StringForCard { get; set; }

        #endregion

        /// <summary>
        /// Based on provided name and suit will create a new card.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="suit"></param>
        public StandardCard(CardName name, CardSuit suit)
        {
            Name = ConvertName(name, suit);
            Suit = ConvertSymbol(suit);
            Value = ConvertValue(name);
            StringForCard = ConvertStringForCard(name, suit);
        }

        //TODO: Should these remain as static helpers or if I branch out to classes for Ace - King would that prevent the need for these methods?
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

        //TODO: Break HandForConsole into its own class
        /// <summary>
        /// Return an array of strings representing the cards in the provided hand.
        /// </summary>
        /// <param name="handToDraw"></param>
        /// <returns></returns>
        public static string[] HandForConsole(List<StandardCard> handToDraw)
        {
            // string to return at the end
            string[] handToReturn = new string[CardLength + 1];
            // loop through each card in hand to draw
            foreach (var card in handToDraw)
            {
                // the array for the card we are adding to the hand
                var cardToAdd = card.ArrayForConsole();

                //TODO: double check the cardlength + 1 is right
                for (int cardLine = 0; cardLine < CardLength + 1; cardLine++)
                {
                    handToReturn[cardLine] += " " + cardToAdd[cardLine];
                }
            }
            return handToReturn;

        }

        /// <summary>
        /// Provide a string based on the widt
        /// </summary>
        /// <param name="cornerStrings"></param>
        /// <param name="centerString"></param>
        /// <returns></returns>
        public override string[] ArrayForConsole()
        {
            var arrayToReturn = new string[CardLength + 1];
            // cycle through each array
            for (int cardLine = 0; cardLine <= CardLength; cardLine++)
            {
                // add to stringToReturn based on the current index
                switch (cardLine)
                {
                    case int line when line == 0:
                        arrayToReturn[cardLine] += CardTopLine();
                        break;
                    case int line when line == TopRightStartIndex[0]:
                        arrayToReturn[cardLine] += StringGenerator.FirstMidInsertMidFirst(CardWidth, '|', ' ', TopRightStartIndex[1], StringForCard);
                        break;
                    case int line when line == BottomLeftStartIndex[0]:
                        arrayToReturn[cardLine] += StringGenerator.FirstMidInsertMidFirst(CardWidth, '|', ' ', BottomLeftStartIndex[1], StringForCard);
                        break;
                    case int line when line == SymbolIndex[0]:
                        arrayToReturn[cardLine] += StringGenerator.FirstMidInsertMidFirst(CardWidth, '|', ' ', SymbolIndex[1], Suit);
                        break;
                    case int line when line == CardLength:
                        arrayToReturn[cardLine] += CardBottomLine(); ;
                        break;
                    default:
                        arrayToReturn[cardLine] += CardEmptyLine();
                        break;
                }
            }
            return arrayToReturn;
        }

        /// <summary>
        /// Return the string for this card with the symbol and cardstring hidden by "???"
        /// </summary>
        /// <param name="hideCard"></param>
        /// <returns></returns>
        public string[] CardForConsole(bool hideCard)
        {
            var stringToReturn = ArrayForConsole();
            if(hideCard)
            {
                stringToReturn[TopRightStartIndex[0]] = StringGenerator.FirstMidInsertMidFirst(CardWidth, '|', ' ', TopRightStartIndex[1], "???");
                stringToReturn[BottomLeftStartIndex[0]] = StringGenerator.FirstMidInsertMidFirst(CardWidth, '|', ' ', BottomLeftStartIndex[1], "???");
                stringToReturn[SymbolIndex[0]] = StringGenerator.FirstMidInsertMidFirst(CardWidth, '|', ' ', SymbolIndex[1], "???");
            }          
            return stringToReturn;
        }

    }


}

