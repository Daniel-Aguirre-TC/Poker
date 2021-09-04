using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    interface IDealCards
    {
        public void CheckHands();

        public virtual void ShuffleDeck()
        {
            //TODO: Create a method to shuffle the deck
        }

        /// <summary>
        /// Foreach Card.CardSuit, we will add a new card to the deck foreach Card.CardName
        /// </summary>
        public virtual void PopulateDeck(List<Card> deck)
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
        /// <param name="deckToDealFrom"></param>
        /// <param name="HandToDealTo"></param>
        /// <returns></returns>
        public virtual Card DealCard(List<Card> deckToDealFrom, List<Card> HandToDealTo)
        {
            // random object used to pull a random card.
            var random = new Random();
            var indexOfCardToPull = random.Next(0, deckToDealFrom.Count - 1);
            // store the string of card pulled in cardPulled
            Card cardPulled = deckToDealFrom[indexOfCardToPull];
            // remove the card pulled from this instance of deck
            deckToDealFrom.RemoveAt(indexOfCardToPull);
            // if deck is now empty, then repopulate.
            if (deckToDealFrom.Count == 0)
            {
                PopulateDeck(deckToDealFrom);
            }
            // return cardPulled string.
            return cardPulled;
        }

    }
}
