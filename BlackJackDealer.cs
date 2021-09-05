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


        /// <summary>
        /// calculate the hand. If the hand surpasses 21 and the player has an ace, then will return the hand with ten points reduced.
        /// </summary>
        /// <param name="handToCheck"></param>
        /// <returns></returns>
        public int CalculateHand(List<Card> handToCheck)
        {
            bool foundAnAce = false;
            int sum = 0;
            foreach (var card in handToCheck)
            {
                if(card._Name.Contains("Ace"))
                {
                    foundAnAce = true;
                }
                sum += card._Value;
            }
            if(sum > 21 && foundAnAce)
            {
                return sum - 10;
            }
            return sum;


        }

        public void CheckHands()
        {
            foreach (var player in AllPlayers)
            {

            }

        }

        /// <summary>
        /// Deal two cards to each player. If the player receiving card is a user player then display the card received.
        /// </summary>
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
