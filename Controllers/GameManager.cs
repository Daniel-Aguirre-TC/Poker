﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public static class GameManager
    {
        public static Game CurrentGame { get; set; }
        static bool ProgramRunning = false;
        public static List<UserPlayer> Players { get; set; }

        /// <summary>
        /// Static constructor will instantiate the List of players
        /// </summary>
        static GameManager()
        {
            Players = new List<UserPlayer>();
        }

        /// <summary>
        /// Called from Program, will Greet the user, ask how many players to create, and then start the requested game.
        /// </summary>
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

            while(ProgramRunning)
            {
                GetGameType();
                CurrentGame.StartGame();
                //TODO: Ask the player if they wish to return to chose a game, or end the application.

            }

        }

        /// <summary>
        /// Display a message to greet the user when the application opens.
        /// </summary>
        static void GreetUser()
        {
            ConsoleController.PrintCenteredVerticalHorizontal(new string[]{
                "Welcome to Red Rain Casino!", "",
                "Thank you for taking the time to play my Poker Application.", "",
                "Created by Daniel Aguirre. "
            }, true);
            ConsoleController.Clear(true);
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
            int option = InputController.OptionList(message, options, inputRequestMessage);
            switch (option)
            {
                case 1:
                    ConsoleController.PrintCenteredVerticalHorizontal(new string[]
                    {
                        "One Player Selected.", "",
                        "Press any key to continue. "
                    }, true, true);
                    return 1;
                case 2:
                    ConsoleController.PrintCenteredVerticalHorizontal("I'm sorry, two player is not yet set up. ", true, true);
                    return GetPlayerCount();

                default:
                    ConsoleController.PrintCenteredVerticalHorizontal("Error selecting players. Returning to previous screen. ", true, true);
                    return GetPlayerCount();
            }

        }

        /// <summary>
        /// Ask the player what type of game they wish to play
        /// </summary>
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
            int option = InputController.OptionList(message, options, inputRequestMessage);
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

        /// <summary>
        /// Change ProgramRunning to false and display a message before ending the application.
        /// </summary>
        static void EndApplication()
        {
            ProgramRunning = false;
            ConsoleController.PrintCenteredVerticalHorizontal(new string[] {
                "Thank you for playing at Red Rain Casino!", "",
                "Come play again any time!", "",
                "Created by Daniel Aguirre. "
                }, true, true);
        }

    }
}