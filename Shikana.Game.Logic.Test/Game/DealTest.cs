using NUnit.Framework;
using Shikana.Cards;
using Shikana.Game.Logic.Game;
using Shikana.Game.Logic.Players;
using System.Collections.Generic;

namespace Shikana.Game.Logic.Test.Game
{
    [TestFixture]
    class DealTest
    {
        [Test]
        public void shouldHaveTwentyCardsInPlayPile()
        {
            Deck deck = new Deck();
            var deck1 = deck.createDeck();
            var deck2 = deck.createDeck();

            var mergedDeck = deck.mergeDecksAndShuffle(deck1, deck2);
            var player1 = new Player();
            var player2 = new Player();

            Deal deal = new Deal(mergedDeck);
            deal.dealPlayPiles(player1, player2);

            Assert.AreEqual(19, player1.PlayPile.Count);
            Assert.AreEqual(19, player2.PlayPile.Count);
            Assert.AreEqual(68, mergedDeck.Count);
        }

        [Test]
        public void shouldHaveFiveCardsInPlayPile()
        {
            Deck deck = new Deck();
            var deck1 = deck.createDeck();
            var deck2 = deck.createDeck();

            var mergedDeck = deck.mergeDecksAndShuffle(deck1, deck2);
            var player1 = new Player();
            var player2 = new Player();

            Deal deal = new Deal(mergedDeck);
            deal.dealPlayersHands(player1, player2);

            Assert.AreEqual(5, player1.Hand.Count);
            Assert.AreEqual(5, player2.Hand.Count);
            Assert.AreEqual(98, deal.Deck.Count);
        }

        [Test]
        public void shouldOnlyHaveFiftyEightCardsLeft()
        {
            Deck deck = new Deck();
            var deck1 = deck.createDeck();
            var deck2 = deck.createDeck();

            var mergedDeck = deck.mergeDecksAndShuffle(deck1, deck2);
            var player1 = new Player();
            var player2 = new Player();

            Deal deal = new Deal(mergedDeck);
            deal.dealPlayersHands(player1, player2);
            deal.dealPlayPiles(player1, player2);

            Assert.AreEqual(58, deal.Deck.Count);
        }

        [Test]
        public void shouldDrawACard()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Player player = new Player();
            player.playersHand(createdDeck.GetRange(0, 1));

            DiscardPile discardPile = new DiscardPile();
            createdDeck.RemoveRange(0, 30);
            Deal deal = new Deal(createdDeck);

            var cardsDrawn = deal.drawCards(player, discardPile);

            Assert.AreEqual(20, deal.Deck.Count);
            Assert.AreEqual(4, cardsDrawn.Count);
        }

        [Test]
        public void ShouldReshuffleTheDeck()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();
            createdDeck.RemoveRange(0, 30);

            Player player = new Player();
            player.playersHand(createdDeck.GetRange(0, 1));

            DiscardPile discardPile = new DiscardPile();
            discardPile.addCardsToDiscardPile(createdDeck.GetRange(0, 24));
            createdDeck.Clear();

            Deal deal = new Deal(createdDeck);
            var cardsDrawn = deal.drawCards(player, discardPile);

            Assert.AreEqual(20, deal.Deck.Count);
            Assert.AreEqual(4, cardsDrawn.Count);

        }

        [Test]
        public void doesNotHaveEnoughCardsToDraw()
        {
            var createdDeck = new List<Card>();

            Deal deal = new Deal(createdDeck);

            Assert.False(deal.doesDeckContainEnoughCards(1));
        }

        [Test]
        public void doesHaveEnoughCardsToDraw()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            Deal deal = new Deal(createdDeck);

            Assert.True(deal.doesDeckContainEnoughCards(1));
        }
    }
}
