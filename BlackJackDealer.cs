using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class BlackJackDealer : GameDealer, IDealCards, IGetInput
    {

        public BlackJackDealer()
        {
            IDealCards.PopulateDeck(GameDeck);
        }

        public void AskHitOrStay()
        {

        }



        public void CheckHands()
        {

        }


        public void FirstDeal()
        {
            // deal two cards to each player.
            for (int i = 0; i < 2; i++)
            {
                for (int playerIndex = 0; playerIndex < AllPlayers.Count - 1; playerIndex++)
                {
                    Card pulled = IDealCards.DealCard(GameDeck);
                    AllPlayers[playerIndex].Hand.Add(pulled);
                    if(AllPlayers[playerIndex] is UserPlayer)
                    {
                        pulled.ReceivedCardScreen();
                    }
                }
            }
        }
    }
}
