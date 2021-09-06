using System;
using System.Collections.Generic;

namespace Poker
{
    public abstract class GameDealer
    {
        public List<Card> GameDeck { get; set; }
        public List<GamePlayer> AllPlayers { get { return GameManager.CurrentGame.Players; }}

        /// <summary>
        /// Constructor for the GameDealer will instantiate a new List<Card> for the GameDeck.
        /// </summary>
        public GameDealer()
        {
            GameDeck = new List<Card>();
        }

        public abstract void CheckHands();
        public abstract void FirstDeal();
        public abstract int CalculateHand(List<Card> handToCheck);

        public virtual void ShuffleDeck()
        {
            //TODO: Create a method to shuffle the deck
        }

        /// <summary>
        /// Foreach Card.CardSuit, we will add a new card to the deck foreach Card.CardName
        /// </summary>
        public static void PopulateDeck(List<Card> deck)
        {
            foreach (Card.CardSuit suit in Enum.GetValues(typeof(Card.CardSuit)))
            {
                foreach (Card.CardName card in Enum.GetValues(typeof(Card.CardName)))
                {
                    deck.Add(new Card(card, suit));
                }
            }
        }

        /// <summary>
        /// Deal a card from the provided deck to the provided hand. 
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="HandToDealTo"></param>
        /// <returns></returns>
        public static Card DealCard(List<Card> deck)
        {
            // random object used to pull a random card.
            var random = new Random();
            var indexOfCardToPull = random.Next(0, deck.Count - 1);
            // store the string of card pulled in cardPulled
            Card cardPulled = deck[indexOfCardToPull];
            // remove the card pulled from this instance of deck
            deck.RemoveAt(indexOfCardToPull);
            // if deck is now empty, then repopulate.
            if (deck.Count == 0)
            {
                PopulateDeck(deck);
            }
            // return cardPulled string.
            return cardPulled;
        }



    }
}