using System;

namespace Poker
{
    public interface IGetInput : IWriteToTheConsole
    {




        public void YesOrNo(string[] everythingAboveQuestion)
        {

        }

        /// <summary>
        /// Print the first array provided above the options. Then print the options to display. Then print the input request message with the last line using Write() instead of WriteLine()
        /// </summary>
        /// <param name="everythingAboveOptions"></param>
        /// <param name="optionsToDisplay"></param>
        /// <param name="inputRequestMessage"></param>
        /// <returns></returns>
        public static int OptionList(string[] everythingAboveOptions, string[] optionsToDisplay, string[] inputRequestMessage)
        {
            int input;
            // create a string[] that is large enough to hold all strings together
            var wholeMessage = new string[everythingAboveOptions.Length + optionsToDisplay.Length + inputRequestMessage.Length];
            // place everything above the options into the wholeMessage
            everythingAboveOptions.CopyTo(wholeMessage, 0);
            // add each option to wholeMessage with "#) " added in front of it.
            for (int optionNumber = 0 ; optionNumber < optionsToDisplay.Length; optionNumber++)
            {
                wholeMessage[everythingAboveOptions.Length + optionNumber] = $"{optionNumber+1}) {optionsToDisplay[optionNumber]}";
            }          
            // Add the input request message to the end of the whole message.
            inputRequestMessage.CopyTo(wholeMessage, wholeMessage.Length - inputRequestMessage.Length);
            // clear the console
            Clear();
            // print the wholeMessage to the screen
            PrintCenteredVerticalHorizontal(wholeMessage, true);
            // if can parse into an int
            char charInput = Console.ReadKey().KeyChar;
            if(int.TryParse(charInput.ToString(), out input))
            {
                if(input != 0 && input <= optionsToDisplay.Length)
                {
                    PrintCenteredVerticalHorizontal("Valid Option Selected.");
                    Clear(true);    
                    return input;
                }
            }
            InvalidInputMessage(charInput);
            return OptionList(everythingAboveOptions, optionsToDisplay, inputRequestMessage);
        }

        /// <summary>
        /// Clear Screen and print a message stating the input received and that it was invalid. Wait for keypress then clear.
        /// </summary>
        /// <param name="inputReceived"></param>
        static void InvalidInputMessage(char inputReceived)
        {
            var input = ConvertEnterChar(inputReceived);

            PrintCenteredVerticalHorizontal(new string[] { 
                $"I'm sorry, {input} is not a valid option.", "",
                "Press any key to return. "       
            }, true);
            Clear(true);
        }

        /// <summary>
        /// Used to convert enter char to prevent issues with printing to the console.
        /// </summary>
        /// <param name="charToConvert"></param>
        /// <returns></returns>
        static string ConvertEnterChar(char charToConvert)
        {
            string lastInput = charToConvert.ToString();
            if (charToConvert == ((char)ConsoleKey.Enter))
            {
                lastInput = "Enter";
            }
            return lastInput;
        }

    }
}