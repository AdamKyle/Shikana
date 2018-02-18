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
            Piles pile = new Piles();
            pile.addCardToPile(new Card((CardSuite)1, (CardValue)1), (PlayablePiles)0);

            Assert.AreEqual(1, pile.PlayPiles[0].Count);
        }

        [Test]
        public void invalidPileForCardToAdd()
        {
            void addCardWithWrongPile()
            {

                Piles piles = new Piles();
                piles.addCardToPile(new Card((CardSuite)1, (CardValue)1), (PlayablePiles)88);
            }

            Assert.Throws(typeof(InvalidPlayPileException), addCardWithWrongPile);
        }

        [Test]
        public void isNotAnAce()
        {
            void addCardWithWrongPile()
            {

                Piles piles = new Piles();
                piles.addCardToPile(new Card((CardSuite)2, (CardValue)3), (PlayablePiles)1);
            }

            Assert.Throws(typeof(MustBeAnAceException), addCardWithWrongPile);
        }

         [Test]
        public void placeASecondCardOnThePile()
        {
            Piles pile = new Piles();
            pile.addCardToPile(new Card((CardSuite)1, (CardValue)1), (PlayablePiles)0);
            pile.addCardToPile(new Card((CardSuite)1, (CardValue)2), (PlayablePiles)0);

            Assert.AreEqual(2, pile.PlayPiles[0].Count);
        }

        [Test]
        public void cannotPlaceASecondCardOnThePile()
        {
            void addCardWithWrongPile()
            {

                Piles piles = new Piles();
                piles.addCardToPile(new Card((CardSuite)2, (CardValue)1), (PlayablePiles)1);
                piles.addCardToPile(new Card((CardSuite)2, (CardValue)5), (PlayablePiles)1);
            }

            Assert.Throws(typeof(InvalidCardValueSizeDifferenceException), addCardWithWrongPile);
        }

        [Test]
        public void pileHasKing()
        {
            Piles pile = new Piles();
            for (var i = 1; i <= 13; i++)
            {
                pile.addCardToPile(new Card((CardSuite)1, (CardValue)i), (PlayablePiles)0);
            }


            Assert.True(pile.checkIfAnyPileHasAKing());
        }

        [Test]
        public void pileDoesNotHaveKing()
        {
            Piles pile = new Piles();
            for (var i = 1; i <= 12; i++)
            {
                pile.addCardToPile(new Card((CardSuite)1, (CardValue)i), (PlayablePiles)0);
            }

            Assert.False(pile.checkIfAnyPileHasAKing());
        }

        [Test]
        public void getDiscardPileWithAKing()
        {
            Piles pile = new Piles();
            for (var i = 1; i <= 13; i++)
            {
                pile.addCardToPile(new Card((CardSuite)1, (CardValue)i), (PlayablePiles)0);
            }

            DiscardPile dp = new DiscardPile();
            DiscardPile discardPile = pile.getPileWithAKing(dp);

            Assert.IsNotNull(discardPile);
            Assert.AreEqual(13, discardPile.DiscardedCards.Count);
        }

        [Test]
        public void returnNullForPileWithKing()
        {
            Piles pile = new Piles();
            for (var i = 1; i <= 12; i++)
            {
                pile.addCardToPile(new Card((CardSuite)1, (CardValue)i), (PlayablePiles)0);
            }

            DiscardPile dp = new DiscardPile();
            DiscardPile discardPile = pile.getPileWithAKing(dp);

            Assert.IsNull(discardPile);
            Assert.False(dp.DiscardedCards.Any());
        }
    }
}
