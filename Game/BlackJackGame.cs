using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Poker.Cards;

namespace Poker
{
    class BlackJackGame : Game
    {
        public bool Hit21 { get; set; }
        public new BlackJackDealer Dealer { get; set; }
        public BlackjackDeckCard DeckCard { get; set; }

        /// <summary>
        /// StillPlaying set to true. Foreach players passed in, add to Players list. MakeNpc() then call StartGame()
        /// </summary>
        /// <param name="players"></param>
        public BlackJackGame(List<UserPlayer> players, BlackJackDealer dealer) : base(players, dealer)
        {
            Dealer = dealer;
            DeckCard = new BlackjackDeckCard();
        }


        public override void StartGame()
        {
            var dealer = MakeNpc(true);
            while (StillPlaying)
            {                
                Dealer.FirstDeal();
                // testing printing to the screen.
                ConsoleController.PrintVerticalHorizontal(Table(dealer, (UserPlayer)Players[0]), true, true);
            }
        }






        /// <summary>
        /// Return an array representing the table for a one player game.
        /// </summary>
        /// <returns></returns>
        string[] Table(Npc dealer, UserPlayer player)
        {
            return new string[] { "Dealers Hand: ", "", "" }.
                                    Concat(dealer.HandArray).
                                    Concat(DeckCard.CardForConsole()).
                                    Concat(player.HandArray).ToArray();
        }


    }
}
