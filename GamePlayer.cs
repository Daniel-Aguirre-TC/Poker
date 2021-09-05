using System.Collections.Generic;
namespace Poker
{
    public abstract class GamePlayer : IWriteToTheConsole
    {
        public static int TotalPlayerCount { get; set; }
        public string Name { get; set; }
        public List<Card> Hand { get; set; }

        public abstract void AssignName();

        public GamePlayer()
        {
            TotalPlayerCount++;
        }

    }
}