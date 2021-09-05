using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public static class GameManager
    {
        public static Game CurrentGame { get; set; }
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
            // GetGameType will start the game needed based on input received.
            GetGameType();
            CurrentGame.StartGame();
        }

        static void GetGameType()
        {

            string[] message = new string[]
            {
                "What type of game would you like to play?", "",
            };
            string[] options = new string[]
            {
                "Black Jack     ",
                "End Application",
            };
            string[] inputRequestMessage = new string[]
            {
                "","Selection: "
            };
            int option = IGetInput.OptionList(message, options, inputRequestMessage);
            switch (option)
            {
                case 1:
                    CurrentGame = new BlackJackGame(Players, new BlackJackDealer());
                    break;
                case 2:
                    EndApplication();
                    break;
            }
        }

        static void EndApplication()
        {
            ProgramRunning = false;
            IWriteToTheConsole.PrintCenteredVerticalHorizontal(new string[] {
                "Thank you for playing at Red Rain Casino!", "",
                "Come play again any time!", "",
                "Created by Daniel Aguirre. "
                }, true);
            IWriteToTheConsole.Clear(true);
        }

        /// <summary>
        /// Ask how many players, and then instantiate a UserPlay for however many entered.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Display a message to greet the user when the application opens.
        /// </summary>
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
