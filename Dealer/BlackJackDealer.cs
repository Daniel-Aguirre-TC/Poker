using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class BlackJackDealer : GameDealer
    {
        /// <summary>
        /// Constructor for BlackJackDealer will populate a new deck.
        /// </summary>
        public BlackJackDealer()
        {
            PopulateDeck(GameDeck);
        }

        public void AskHitOrStay()
        {

        }


        /// <summary>
        /// calculate the hand. If the hand surpasses 21 and the player has an ace, then will return the hand with ten points reduced.
        /// </summary>
        /// <param name="handToCheck"></param>
        /// <returns></returns>
        public override int CalculateHand(List<Card> handToCheck)
        {
            bool foundAnAce = false;
            int sum = 0;
            foreach (var card in handToCheck)
            {
                if(card.Name.Contains("Ace"))
                {
                    foundAnAce = true;
                }
                sum += card.Value;
            }
            if(sum > 21 && foundAnAce)
            {
                return sum - 10;
            }
            return sum;


        }

        /// <summary>
        /// Calculate the score for each player. 
        /// </summary>
        public override void CheckHands()
        {
            foreach (var player in AllPlayers)
            {

            }

        }

        /// <summary>
        /// Deal two cards to each player. If the player receiving card is a user player then display the card received.
        /// </summary>
        public override void FirstDeal()
        {
            // deal two cards to each player.
            for (int i = 0; i < 2; i++)
            {
                for (int playerIndex = 0; playerIndex < AllPlayers.Count; playerIndex++)
                {
                    Card pulled = DealCard(GameDeck);
                    AllPlayers[playerIndex].ReceiveCard(pulled);
                }
            }
        }
    }
}
