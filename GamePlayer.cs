using System.Collections.Generic;
namespace Poker
{
    public abstract class GamePlayer : IWriteToTheConsole
    {
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
        

        public GamePlayer()
        {
            Hand = new List<Card>();
            TotalPlayerCount++;
        }

    }
}