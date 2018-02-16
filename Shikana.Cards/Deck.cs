using Shikana.Cards.CardEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shikana.Cards
{
    public class Deck
    {
        public List<Card> createDeck()
        {
            List<Card> deck = new List<Card>();

            // Suit
            for (var i = 0; i < 4; i++)
            {
                // Card Value
                for (var j = 0; j < 13; j++)
                {
                    Card card = new Card((CardSuite)i + 1, (CardValue)j + 1);

                    if (card.validateCard())
                    {
                        deck.Add(card);
                    }

                }
            }

            // Create a Joker Card
            Card joker = new Card((Joker)1);

            // Add Both Jokers to the deck
            deck.Add(joker);
            deck.Add(joker);

            return deck;
        }

        public List<Card> mergeDecksAndShuffle(List<Card> deck1, List<Card> deck2)
        {
            List<Card> newDeck = deck1.Concat(deck2).ToList();
            return ShuffleDeck(newDeck);
        }

        public List<Card> ShuffleDeck(List<Card> deck)
        {
            List<Card> ShuffledDeck = new List<Card>();
            List<int> NumbersPicked = new List<int>();

            for (var i = 0; i < deck.Count; i++)
            {
                Random randomNumber = new Random();
                bool newIndex = false;
                int newIndexPicked = 0;

                while (!newIndex)
                {
                    newIndexPicked = randomNumber.Next(0, deck.Count);
                    newIndex = true;

                    foreach (int picked in NumbersPicked)
                    {
                        if (picked == newIndexPicked)
                        {
                            newIndex = false;
                        }
                    }
                }

                NumbersPicked.Add(newIndexPicked);
                ShuffledDeck.Add(deck[newIndexPicked]);
            }

            return ShuffledDeck;
        }
    }
}
