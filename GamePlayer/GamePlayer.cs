using System.Collections.Generic;
namespace Poker
{
    public abstract class GamePlayer
    {

        //TODO: Can I make this appear when hovering over TotalPlayerCount?
        /// <summary>
        /// TotalPlayerCount represents all GamePlayers. User players & Npcs
        /// </summary>
        public static int TotalPlayerCount { get; set; }
        public string Name { get; set; }
        public List<Card> Hand { get; set; }

        /// <summary>
        /// Assign name to GamePlayer.
        /// </summary>
        public abstract void AssignName();
        /// <summary>
        /// Message to display after name is assigned.
        /// </summary>
        public abstract void PlayerCreatedMessage();
        
        /// <summary>
        /// Constructor for GamePlayer will instantiate a hand for the Player being created, and will increase Total Player Count by one.
        /// </summary>
        public GamePlayer()
        {
            Hand = new List<Card>();
            TotalPlayerCount++;
        }

    }
}