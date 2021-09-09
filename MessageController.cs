using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public static class MessageController
    {
        static string[] LastMessage { get; set; }
        static string[] currentMessage { get; set; }
        static bool canDisplayPrevious = false;

        /// <summary>
        /// Takes in the ISpeakable object calling the method, and a string representing the messageKey being requested. Uses this
        /// to pull the next message. Before printing the message it will update the LastMessage property so that it can revert
        /// if needed.
        /// </summary>
        /// <param name="speakable"></param>
        /// <param name="messageKey"></param>
        public static void Display(ISpeakable speakable, string messageKey)
        {
            // canDisplayPrevious used to allow going to the last screen provided. Prevent returning multiple times because at this time
            // we are not storing more than one previous message, so including this would allow a pointless loop between the same two messages.
            canDisplayPrevious = true;
            // find the dictionary related to the speakable object calling Display()
            var dictionary = FindSpeaker(speakable);
            // declare a new string[] that will become our new CurrentMessage
            string[] messageFound;
            // find the value needed based on the key provided
            dictionary.TryGetValue(messageKey, out messageFound);
            // update the last message and then current message
            LastMessage = currentMessage;
            currentMessage = messageFound;
            // print the message to the screen.
            ConsoleController.PrintVerticalHorizontal(currentMessage);
            

        }

        /// <summary>
        /// reprint the last page. 
        /// </summary>
        public static void DisplayPrevious()
        {
            canDisplayPrevious = false;
            ConsoleController.PrintVerticalHorizontal(LastMessage);

        }

        static Dictionary<string, string[]> FindSpeaker(ISpeakable speakable)
        {
            switch(speakable)
            {
                case ISpeakable obj when obj is UserPlayer:
                    return PlayerMessages;
                case ISpeakable obj when obj is Npc:
                    return NpcMessages;
                default: 
                    return null;
            }
        }

        static Dictionary<string, string[]> GameMessages = new Dictionary<string, string[]>()
        {

        };


            


        static Dictionary<string, string[]> NpcMessages = new Dictionary<string, string[]>()
        {

        };


        static Dictionary<string, string[]> PlayerMessages = new Dictionary<string, string[]>()
        {

        };
         

    }
}
