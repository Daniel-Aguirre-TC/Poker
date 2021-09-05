using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class BlackJackGame : Game
    {
        public bool Hit21 { get; set; }
        public new BlackJackDealer Dealer { get; set; }

        /// <summary>
        /// StillPlaying set to true. Foreach players passed in, add to Players list. MakeNpc() then call StartGame()
        /// </summary>
        /// <param name="players"></param>
        public BlackJackGame(List<UserPlayer> players, BlackJackDealer dealer) : base(players, dealer)
        {
            Dealer = dealer;

        }
        

        static string[] deckConsoleImage = new string[]
        {
                    " _____________ ",
                    "|             |",
                    "|             |",
                    "|  Daniel's   |",
                    "|     Black   |",
                    "|       Jack  |",
                    "|             |",
                    "|   ♠ ♣ ♥ ♦   |",
                    "|   ~ Deck ~  |",
                    "|   ♠ ♣ ♥ ♦   |",
                    "|             |",
                    "|_____________|",
        };


        public override void StartGame()
        {
            while(StillPlaying)
            {
                Dealer.FirstDeal();

                IWriteToTheConsole.Clear(true);
            }


        }
    }
}
