using System.Collections.Generic;
using System.Linq;
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
        List<Card> Hand { get; set; }
        public int HandCount { get => Hand.Count; }
        public string[] HandArray { get => Card.HandForConsole(Hand); }

        /// <summary>
        /// Constructor for GamePlayer will instantiate a hand for the Player being created, and will increase Total Player Count by one.
        /// </summary>
        public GamePlayer()
        {
            Hand = new List<Card>();
            TotalPlayerCount++;
        }

        #region Player Creation Input and Messages

        /// <summary>
        /// Assign name to GamePlayer.
        /// </summary>
        public abstract void AssignName();
        
        /// <summary>
        /// Message to display after name is assigned.
        /// </summary>
        public abstract void PlayerCreatedMessage();

        #endregion

        public virtual void ReceiveCard(Card cardReceiving)
        {
            Hand.Add(cardReceiving);
            ReceivedCardScreen(cardReceiving);
        }
   
        /// <summary>
        /// Default message to display when a GamePlayer receives a card.
        /// </summary>
        public virtual void ReceivedCardScreen(Card cardReceived)
        {
            string a = cardReceived.Name.Contains("Eight") || cardReceived.Name.Contains("Ace") ? "an" : "a";
            // message to display under the card.
            var message = new string[]
            {
                "", "", $"{Name} was dealt {a} {cardReceived.Name}!", "", "Press any key to continue. "
            };
            string[] cardAndMessage = cardReceived.CardStringArray.Concat(message).ToArray();
            // Print the card centered to the screen with message above concated below it.
            ConsoleController.PrintCenteredVerticalHorizontal(cardAndMessage, true, true);
        }

    }
}