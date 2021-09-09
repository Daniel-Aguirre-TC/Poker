using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Cards
{
    public abstract class Card
    {

        public string Name { get; set; }
        public string[] CardStringArray { get { return ArrayForConsole(); } }

        #region Static Card Size Properties

        // Indexs for changing the string shown on the card. If the card is resized these will need to be changed for layout purposes.
        protected static int[] TopRightStartIndex = { 3, 13 };
        protected static int[] BottomLeftStartIndex = { 11, 3 };
        protected static int[] SymbolIndex = { 7, 9 };

        //TODO: If my card length is 11 and my goal is two, how can I calculate this on a changing length value?
        // I think I need to start by getting a few different scenerios of what all indexs/sizes are and then creating a formula to get the desired outcome in all situations
        // think how functions are taught in math in grade school

        // Width and Length of the card. Must change indexs above if these are changed.
        protected static int CardWidth = 18;
        protected static int CardLength = 13;

        #endregion

        public abstract string[] ArrayForConsole();
        protected virtual string CardTopLine()
        {
            return StringGenerator.FirstMiddleFirst(CardWidth, ' ', '_');
        }
        protected virtual string CardBottomLine()
        {
            return StringGenerator.FirstMiddleFirst(CardWidth, '|', '_');
        }
        protected virtual string CardEmptyLine()
        {
            return StringGenerator.FirstMiddleFirst(CardWidth, '|', ' ');
        }

    }
}
