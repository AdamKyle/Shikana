using System;
using NUnit.Framework;

namespace Skikana.Cards.Test
{
    [TestFixture]
    class DeckTest
    {
        [Test]
        public void deckShouldBeCreated()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Assert.AreEqual(54, createdDeck.Count);
        }

        [Test]
        public void testShufflingOfDeck()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();
            var deckToShuffle = deck.createDeck();

            Assert.AreNotSame(
                createdDeck[0].CardValue, 
                deck.ShuffleDeck(deckToShuffle)[0].CardValue
            );
        }

        [Test]
        public void mergeTwoDecksAndShuffleThem()
        {
            Deck deck = new Deck();

            var deck1 = deck.createDeck();
            var deck2 = deck.createDeck();

            Assert.AreEqual(108, deck.mergeDecksAndShuffle(deck1, deck2).Count);
        }
    }
}
