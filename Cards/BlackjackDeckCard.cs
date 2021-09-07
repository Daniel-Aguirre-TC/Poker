using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Cards
{
    public class BlackjackDeckCard : Card
    {

        static string[] deckConsoleImage = new string[]
        {
            "", "",
            " ________________ ",
            "|                |",
            "|   Daniel's     |",
            "|                |",
            "|       Black    |",
            "|                |",
            "|   ♠      Jack  |",
            "| ♥   ♦          |",
            "|   ♣            |",
            "|                |",
            "|     ♠ ♣ ♥ ♦    |",
            "|       Deck     |",
            "|     ♠ ♣ ♥ ♦    |",
            "|________________|",
            "", "",
        };

        public override string[] CardForConsole()
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
                    case int line when line == 2:
                        arrayToReturn[cardLine] += StringGenerator.FirstMidInsertMidFirst(CardWidth, '|', ' ', 4, "Daniel's");
                        break;
                    case int line when line == 4:
                        arrayToReturn[cardLine] += StringGenerator.FirstMidInsertMidFirst(CardWidth, '|', ' ', 8, "Black");
                        break;
                    case int line when line == 6:
                        arrayToReturn[cardLine] += StringGenerator.FirstMidInsertMidFirst(CardWidth, '|', ' ', 4, "♠      Jack");
                        break;
                    case int line when line == 7:
                        arrayToReturn[cardLine] += StringGenerator.FirstMidInsertMidFirst(CardWidth, '|', ' ', 2, "♥   ♦");
                        break;
                    case int line when line == 8:
                        arrayToReturn[cardLine] += StringGenerator.FirstMidInsertMidFirst(CardWidth, '|', ' ', 4, "♣");
                        break;
                    case int line when line == 10:
                    case int elseLine when elseLine == 12:
                        arrayToReturn[cardLine] += StringGenerator.FirstMidInsertMidFirst(CardWidth, '|', ' ', 6, "♠ ♣ ♥ ♦");
                        break;
                    case int line when line == 11:
                        arrayToReturn[cardLine] += StringGenerator.FirstMidInsertMidFirst(CardWidth, '|', ' ', 8, "Deck");
                        break;
                    case int line when line == CardLength:
                        arrayToReturn[cardLine] += CardBottomLine();
                        break;
                    default:
                        arrayToReturn[cardLine] += CardEmptyLine();
                        break;
                }
            }
            return arrayToReturn;
        }
    }
}
