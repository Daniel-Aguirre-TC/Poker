using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class BlackJackGame : Game
    {
        public bool Hit21 { get; set; }



        





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
            throw new NotImplementedException();
        }
    }
}
