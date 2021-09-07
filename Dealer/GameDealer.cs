using System;
using System.Collections.Generic;

namespace Poker
{
    public abstract class GameDealer
    {
        public List<StandardCard> GameDeck { get; set; }
        public List<GamePlayer> AllPlayers { get { return GameManager.CurrentGame.Players; }}

        /// <summary>
        /// Constructor for the GameDealer will instantiate a new List<Card> for the GameDeck.
        /// </summary>
        public GameDealer()
        {
            GameDeck = new List<StandardCard>();
        }

        public abstract void CheckHands();
        public abstract void FirstDeal();
        public abstract int CalculateHand(List<StandardCard> handToCheck);

        public virtual void ShuffleDeck()
        {
            //TODO: Create a method to shuffle the deck
        }

        /// <summary>
        /// Foreach Card.CardSuit, we will add a new card to the deck foreach Card.CardName
        /// </summary>
        public static void PopulateDeck(List<StandardCard> deck)
        {
            foreach (StandardCard.CardSuit suit in Enum.GetValues(typeof(StandardCard.CardSuit)))
            {
                foreach (StandardCard.CardName card in Enum.GetValues(typeof(StandardCard.CardName)))
                {
                    deck.Add(new StandardCard(card, suit));
                }
            }
        }

        /// <summary>
        /// Deal a card from the provided deck to the provided hand. 
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="HandToDealTo"></param>
        /// <returns></returns>
        public static StandardCard DealCard(List<StandardCard> deck)
        {
            // random object used to pull a random card.
            var random = new Random();
            var indexOfCardToPull = random.Next(0, deck.Count - 1);
            // store the string of card pulled in cardPulled
            StandardCard cardPulled = deck[indexOfCardToPull];
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