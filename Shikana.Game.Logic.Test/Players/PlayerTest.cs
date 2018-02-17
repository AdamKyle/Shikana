using NUnit.Framework;
using Shikana.Cards;
using Shikana.Cards.CardEnums;
using Shikana.Game.Logic.Players;
using System;

namespace Shikana.Game.Logic.Test.Players
{
    [TestFixture]
    class PlayerTest
    {
        [Test]
        public void handHasCards()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Player player = new Player();
            player.playersHand(createdDeck.GetRange(0, 5));

            Assert.AreEqual(5, player.Hand.Count);
        }

        [Test]
        public void playPileHasCards()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Player player = new Player();
            player.playPile(createdDeck.GetRange(0, 20));

            Assert.AreEqual(19, player.PlayPile.Count);
            Assert.AreEqual(1, player.PlayPileTopCard.Count);
        }

        [Test]
        public void topCardShouldRecycle()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Player player = new Player();
            player.playPile(createdDeck.GetRange(0, 20));

            var topCard = player.PlayPileTopCard[0];
            player.getTopCard();

            Assert.AreNotSame(topCard, player.PlayPile[0]);
            Assert.AreEqual(18, player.PlayPile.Count);
        }

        [Test]
        public void topCardHasMoreThenOnePlayableCard()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Player player = new Player();
            player.playPile(createdDeck.GetRange(0, 20));

            int oneCardValueHigher = (int)player.PlayPileTopCard[0].CardValue + 1;

            player.addCardToTopCard(new Card((CardSuite)0, (CardValue)oneCardValueHigher));

            Assert.AreEqual(2, player.PlayPileTopCard.Count);
            Assert.AreEqual(19, player.PlayPile.Count);
        }

        [Test]
        public void playingTopCardShouldNotRecycle()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Player player = new Player();
            player.playPile(createdDeck.GetRange(0, 20));

            int oneCardValueHigher = (int)player.PlayPileTopCard[0].CardValue + 1;

            player.addCardToTopCard(new Card((CardSuite)1, (CardValue)oneCardValueHigher));

            Assert.AreEqual(2, player.PlayPileTopCard.Count);

            Card bottomCard = player.PlayPileTopCard[1];
            player.getTopCard();

            Assert.AreEqual(1, player.PlayPileTopCard.Count);
            Assert.AreEqual(19, player.PlayPile.Count);
        }

        [Test]
        public void isNotHigherOrIsEqual()
        {
            void throwsError()
            {
                Deck deck = new Deck();
                var createdDeck = deck.createDeck();

                Player player = new Player();
                player.playPile(createdDeck.GetRange(0, 20));

                player.addCardToTopCard(createdDeck[0]);
            }



            Assert.Throws(typeof(Exception), throwsError);
        }

        [Test]
        public void isJoker()
        {
            void throwError()
            {
                Deck deck = new Deck();
                var createdDeck = deck.createDeck();

                Player player = new Player();
                player.playPile(createdDeck.GetRange(0, 20));

                player.addCardToTopCard(new Card((Joker)0));
            }


            Assert.Throws(typeof(Exception), throwError);
        }

        [Test]
        public void hasNoCardsLeftInPlayPile()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Player player = new Player();
            player.playPile(createdDeck.GetRange(0, 2));
            player.getTopCard();

            Assert.AreEqual(0, player.PlayPile.Count);
        }

        [Test]
        public void hasNotWon()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Player player = new Player();
            player.playPile(createdDeck.GetRange(0, 2));
            player.getTopCard();

            Assert.False(player.hasWon());
        }

        [Test]
        public void hasWon()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Player player = new Player();
            player.playPile(createdDeck.GetRange(0, 1));
            player.getTopCard();

            Assert.True(player.hasWon());
            Assert.AreEqual(0, player.PlayPile.Count);
            Assert.AreEqual(0, player.PlayPileTopCard.Count);
        }

        [Test]
        public void drawsACard()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Player player = new Player();
            player.playersHand(createdDeck.GetRange(0, 5));

            Assert.AreEqual(createdDeck[4].CardValue, player.getFromHand(4).CardValue);
        }

        [Test]
        public void cannotPlayCardFromEmptyHand()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Player player = new Player();
            player.playersHand(createdDeck.GetRange(0, 1));
            player.getFromHand(0);

            Assert.IsNull(player.getFromHand(0));
        }

        [Test]
        public void outOfBoundsShouldThrowError()
        {
            void drawCard()
            {
                Deck deck = new Deck();
                var createdDeck = deck.createDeck();

                Player player = new Player();
                player.playersHand(createdDeck.GetRange(0, 1));
                player.getFromHand(999);
            }

            Assert.Throws(typeof(ArgumentOutOfRangeException), drawCard);
        }

        [Test]
        public void hasToDrawACard()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Player player = new Player();
            player.playersHand(createdDeck.GetRange(0, 5));
            player.getFromHand(3);

            Assert.True(player.hasToDraw());
        }


        [Test]
        public void shasToDrawACardShouldBeFalse()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Player player = new Player();
            player.playersHand(createdDeck.GetRange(0, 5));

            Assert.False(player.hasToDraw());
        }

        [Test]
        public void hasNoCardsLeftInHand()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Player player = new Player();
            player.playersHand(createdDeck.GetRange(0, 1));
            player.getFromHand(0);

            Assert.True(player.hasNoCardsLeftInHand());
        }

        [Test]
        public void hasNoCardsLeftInHandShouldBeFalse()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Player player = new Player();
            player.playersHand(createdDeck.GetRange(0, 1));

            Assert.False(player.hasNoCardsLeftInHand());
        }
    }
}
