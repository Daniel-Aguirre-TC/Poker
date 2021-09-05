using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public static class GameManager
    {
        static bool ProgramRunning = false;
        public static List<UserPlayer> Players { get; set; }

        static GameManager()
        {
            Players = new List<UserPlayer>();
        }



        public static void StartProgram()
        {
            GreetUser();
            ProgramRunning = true;
            var playerCount = GetPlayerCount();
            for (int i = 0; i < playerCount; i++)
            {
                Players.Add(new UserPlayer());
            }


        }

        static int GetPlayerCount()
        {
            string[] message = new string[]
            {
                "How many players will be joining us today?", "",
            };
            string[] options = new string[]
            {
                "One Player ", "Two Players"
            };
            string[] inputRequestMessage = new string[]
            {
                "","Players:   "
            };
            int option = IGetInput.OptionList(message, options, inputRequestMessage);
            switch(option)
            {
                case 1:
                    IWriteToTheConsole.PrintCenteredVerticalHorizontal(new string[]
                    {
                        "One Player Selected.", "",
                        "Press any key to continue. "
                    }, true);
                    IWriteToTheConsole.Clear(true);
                    return 1;
                case 2:
                    IWriteToTheConsole.PrintCenteredVerticalHorizontal("I'm sorry, two player is not yet set up.");
                    IWriteToTheConsole.Clear(true);
                    return GetPlayerCount();

                default:
                    IWriteToTheConsole.PrintCenteredVerticalHorizontal("Error selecting players. Returning to previous screen.");
                    IWriteToTheConsole.Clear(true);
                    return GetPlayerCount();
            }

        }

        static void GreetUser()
        {
            IWriteToTheConsole.PrintCenteredVerticalHorizontal(new string[]{
                "Welcome to Red Rain Casino!", "",
                "Thank you for taking the time to play my Poker Application.", "",
                "Created by Daniel Aguirre. "
            }, true);
            IWriteToTheConsole.Clear(true);
        }

    }
}
