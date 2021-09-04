using System;

namespace Poker
{
    class Program : IGetInput
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 60);

            var messageAboveOptions = new string[]
            {
                "Here is a message I wrote.", "",
                "I like to use double spacing.", "",
                "Next I'll show options, with the #) added by a method.",""
            };
            var optionsAvailable = new string[]
            {
                "Say Something ",
                "Leave         ",
                "Wait          ",
                "Another Option"
            };
            var inputRequestMessage = new string[]
            {
                "", "Input: "
            };

            IGetInput.OptionList(messageAboveOptions, optionsAvailable, inputRequestMessage);

            /*
            foreach (var card in Deck.baseDeck)
            {
                card.ReceivedCardScreen();
            }
            */

        }
    }
}
