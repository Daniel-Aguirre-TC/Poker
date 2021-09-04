﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    interface IWriteToTheConsole
    {

        #region SkipLines

        /// <summary>
        /// Skip lines to center the current line vertically.
        /// </summary>
        static void SkipLines()
        {
            for (int i = 0; i < (Console.WindowHeight / 2); i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Skip a specified number of lines.
        /// </summary>
        /// <param name="linesToSkip"></param>
        static void SkipLines(int linesToSkip)
        {
            for (int i = 0; i < linesToSkip; i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Skip lines based on a provided array of strings to center the array of strings vertically.
        /// </summary>
        /// <param name="arrayToReference"></param>
        static void SkipLines(string[] arrayToReference)
        {
            for (int i = 0; i < (Console.WindowHeight / 2) - (arrayToReference.Length); i++)
            {
                Console.WriteLine();
            }
        }

        #endregion



        /// <summary>
        /// Print the provided string, centered horizontally, in a Console.WriteLine.
        /// </summary>
        static void PrintCenteredHorizontal(string textToPrint)
        {
            Console.WriteLine(CenterHorizontal(textToPrint));
        }

        /// <summary>
        /// Print the provided string, centered horizontally. If dontEndLine is true, then will use Console.Write() instead of WriteLine.
        /// </summary>
        /// <param name="textToPrint"></param>
        /// <param name="dontEndLine"></param>
        static void PrintCenteredHorizontal(string textToPrint, bool dontEndLine)
        {
            if (dontEndLine)
            {
                Console.Write(CenterHorizontal(textToPrint));
            }
            else PrintCenteredHorizontal(textToPrint);
        }

        // print the provided string or string[] centered on the current line.
        static void PrintCenteredHorizontal(string[] arrayOfStringsToPrint)
        {
            foreach (var str in arrayOfStringsToPrint)
            {
                PrintCenteredHorizontal(str);
            }
        }

        static void PrintCenteredHorizontal(string[] arrayOfStringsToPrint, bool dontEndLine)
        {
            if (dontEndLine)
            {
                for (int i = 0; i < arrayOfStringsToPrint.Length; i++)
                {
                    // if it's not on the last cycle
                    if (i != arrayOfStringsToPrint.Length - 1)
                    {
                        Console.WriteLine(CenterHorizontal(arrayOfStringsToPrint[i]));
                    }
                    else Console.Write(CenterHorizontal(arrayOfStringsToPrint[i]));
                }
            }
            else PrintCenteredHorizontal(arrayOfStringsToPrint);
        }

        static void PrintCenteredHorizontal(string[] arrayOfStringsToPrint, bool dontEndLine, bool trimEnd)
        {
            if (dontEndLine && trimEnd)
            {
                for (int i = 0; i < arrayOfStringsToPrint.Length; i++)
                {
                    // if it's not on the last cycle
                    if (i != arrayOfStringsToPrint.Length - 1)
                    {
                        Console.WriteLine(CenterHorizontal(arrayOfStringsToPrint[i].TrimEnd()));
                    }
                    else Console.Write(CenterHorizontal(arrayOfStringsToPrint[i].TrimEnd()));
                }
            }
            else if (!dontEndLine && trimEnd)
            {
                foreach (var str in arrayOfStringsToPrint)
                {
                    if (str != null)
                    {
                        // adding special if statement to not trim the first array to avoid issues with the cards being printed.
                        if (str == arrayOfStringsToPrint[0])
                        {
                            PrintCenteredHorizontal(str);
                        }
                        else
                        {
                            PrintCenteredHorizontal(str.TrimEnd());
                        }
                    }

                }
            }
            else if (dontEndLine && !trimEnd)
            {
                PrintCenteredHorizontal(arrayOfStringsToPrint, dontEndLine);
            }
            else PrintCenteredHorizontal(arrayOfStringsToPrint);
        }

        //Clear Console, then print the provided string or string[] centered vertically and horizontally

        static void PrintCenteredVerticalHorizontal(string stringToPrint)
        {
            Console.Clear();
            SkipLines();
            Console.WriteLine(CenterHorizontal(stringToPrint));
        }
        static void PrintCenteredVerticalHorizontal(string[] arrayOfStringsToPrint)
        {
            Console.Clear();
            SkipLines(arrayOfStringsToPrint);
            foreach (var textLine in arrayOfStringsToPrint)
            {
                Console.WriteLine(CenterHorizontal(textLine));
            }
        }
        // CenterMidScreenAndPrint but if bool is true then we will do a Write instead of WriteLine.
        static void PrintCenteredVerticalHorizontal(string stringToPrint, bool dontEndLine)
        {
            Console.Clear();
            SkipLines(Console.WindowHeight / 2);
            if (dontEndLine)
            {
                Console.Write(CenterHorizontal(stringToPrint));
            }
            else Console.WriteLine(CenterHorizontal(stringToPrint));
        }
        static void PrintCenteredVerticalHorizontal(string[] arrayOfStringsToPrint, bool dontEndLastLine)
        {
            Console.Clear();
            SkipLines(arrayOfStringsToPrint);
            for (int i = 0; i < arrayOfStringsToPrint.Length; i++)
            {
                // if it's not on the last cycle
                if (i != arrayOfStringsToPrint.Length - 1)
                {
                    Console.WriteLine(CenterHorizontal(arrayOfStringsToPrint[i]));
                }
                else Console.Write(CenterHorizontal(arrayOfStringsToPrint[i]));
            }
        }
        static void PrintCenteredVerticalHorizontal(string[] arrayOfStringsToPrint, int lengthOfStringToMatchPaddingOf)
        {
            Console.Clear();
            for (int i = 0; i < (Console.WindowHeight / 2) - (arrayOfStringsToPrint.Length); i++)
            {
                Console.WriteLine();
            }
            for (int i = 0; i < arrayOfStringsToPrint.Length; i++)
            {
                // if it's not on the last cycle
                if (i != arrayOfStringsToPrint.Length - 1)
                {
                    Console.WriteLine(CenterHorizontal(arrayOfStringsToPrint[i]));
                }
                else Console.Write(arrayOfStringsToPrint[i].PadLeft((Console.WindowWidth / 2) - ((lengthOfStringToMatchPaddingOf / 2) - arrayOfStringsToPrint[i].Length)));
            }
        }


        /// <summary>
        /// Return the provided string, with padding to the left to center it horizontally on the screen based on Console.WindowWidth
        /// </summary>
        /// <param name="textToCenter"></param>
        /// <returns></returns>
        static string CenterHorizontal(string textToCenter)
        {
            if (textToCenter == null)
            {
                return "";
            }
            return textToCenter.PadLeft((int)MathF.Round((Console.WindowWidth / 2) + (textToCenter.Length / 2)));
        }

        /// <summary>
        /// After the user presses any key clear the console.
        /// </summary>
        static void ClearAfterKeyPress()
        {
            Console.ReadKey();
            Console.Clear();
        }



    }
}
