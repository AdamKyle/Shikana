using NUnit.Framework;
using Shikana.Cards;
using Shikana.Cards.CardEnums;
using Shikana.Game.Logic.Game;
using Shikana.Game.Logic.Game.PlayPiles;
using System;
using System.Linq;

namespace Shikana.Game.Logic.Test.Game.PlayPiles
{
    [TestFixture]
    class PilesTest
    {
        [Test]
        public void addACardToThePlayPile()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            var createdCardForPile = new PileCard(createdDeck[0], (PlayPile)1);
            Piles pile = new Piles();
            pile.addCardToPile(createdCardForPile);

            Assert.AreEqual(1, pile.CardForPile.Count);
            Assert.AreEqual(createdCardForPile.Card.CardValue, pile.CardForPile[0].Card.CardValue);
        }

        [Test]
        public void invalidPileForCardToAdd()
        {
            void addCardWithWrongPile()
            {
                Deck deck = new Deck();
                var createdDeck = deck.createDeck();

                var createdCardForPile = new PileCard(createdDeck[0], (PlayPile)999);
                Piles pile = new Piles();
                pile.addCardToPile(createdCardForPile);
            }

            Assert.Throws(typeof(Exception), addCardWithWrongPile);
        }

        [Test]
        public void pileHasKing()
        {
            Card card = new Card((CardSuite)1, (CardValue)13);
            Piles pile = new Piles();
            var createdCardForPile = new PileCard(card, (PlayPile)1);
            pile.addCardToPile(createdCardForPile);

            Assert.True(pile.checkIfAnyPileHasAKing());
        }

        [Test]
        public void pileDoesNotHaveKing()
        {
            Card card = new Card((CardSuite)1, (CardValue)10);
            Piles pile = new Piles();
            var createdCardForPile = new PileCard(card, (PlayPile)1);
            pile.addCardToPile(createdCardForPile);

            Assert.False(pile.checkIfAnyPileHasAKing());
        }

        [Test]
        public void getDiscardPileWithAKing()
        {
            Card card = new Card((CardSuite)1, (CardValue)13);
            Piles pile = new Piles();
            var createdCardForPile = new PileCard(card, (PlayPile)1);
            pile.addCardToPile(createdCardForPile);
            DiscardPile dp = new DiscardPile();
            DiscardPile discardPile = pile.getPileWithAKing(dp);

            Assert.IsNotNull(discardPile);
            Assert.AreEqual(1, discardPile.DiscardedCards.Count);
        }

        [Test]
        public void returnNullForPileWithKing()
        {
            Card card = new Card((CardSuite)1, (CardValue)10);
            Piles pile = new Piles();
            var createdCardForPile = new PileCard(card, (PlayPile)1);
            pile.addCardToPile(createdCardForPile);
            DiscardPile dp = new DiscardPile();
            var discardPile = pile.getPileWithAKing(dp);

            Assert.IsNull(discardPile);
            Assert.False(dp.DiscardedCards.Any());
        }
    }
}
