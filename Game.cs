using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public abstract class Game : IGetInput
    {
        public List<GamePlayer> Players { get; set; }
        GameDealer Dealer = new GameDealer();
        public bool StillPlaying { get; set; }



        public abstract void StartGame();



    }
}
