using NUnit.Framework;
using Shikana.Cards;
using Shikana.Game.Logic.Game;

namespace Shikana.Game.Logic.Test.Game
{
    [TestFixture]
    class DiscardPileTest
    {
        [Test]
        public void addCardsToDiscardPile()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();

            DiscardPile dp = new DiscardPile();
            dp.addCardsToDiscardPile(createdDeck);

            Assert.AreNotEqual(0, dp.DiscardedCards.Count);
        }
    }
}
