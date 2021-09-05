using System.Collections.Generic;

namespace Poker
{
    public abstract class GameDealer
    {
        public List<Card> GameDeck { get; set; }
        public List<GamePlayer> AllPlayers { get { return GameManager.CurrentGame.Players; }}

        public GameDealer()
        {
            GameDeck = new List<Card>();
        }



    }
}