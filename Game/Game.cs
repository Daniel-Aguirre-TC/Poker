using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public abstract class Game
    {
        public List<GamePlayer> Players { get; set; }
        public GameDealer Dealer { get; set; }
        public bool StillPlaying { get; set; }

        /// <summary>
        /// StillPlaying set to true. Create a Dealer and Players list. Foreach players passed in, add to Players list. MakeNpc() then StartGame()
        /// </summary>
        /// <param name="players"></param>
        public Game(List<UserPlayer> players, GameDealer dealer)
        {
            StillPlaying = true;
            // Dealer = dealer;
            Players = new List<GamePlayer>();
            foreach (var player in players)
            {
                Players.Add(player);
            }
        }

        /// <summary>
        /// StartGame should be the first method called for each Game.
        /// </summary>
        public abstract void StartGame();

        /// <summary>
        /// Create an npc and add it to the Players list.
        /// </summary>
        public virtual void MakeNpc()
        {
            Players.Add(new Npc());
        }

        /// <summary>
        /// Create an Npc, if isTrue then will be named "Dealer"
        /// </summary>
        /// <param name="isDealer"></param>
        public virtual void MakeNpc(bool isDealer)
        {
            Players.Add(new Npc(isDealer));
        }


    }
}
