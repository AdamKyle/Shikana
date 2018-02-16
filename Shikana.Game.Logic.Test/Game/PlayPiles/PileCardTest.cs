using NUnit.Framework;
using Shikana.Cards;
using Shikana.Game.Logic.Game.PlayPiles;

namespace Shikana.Game.Logic.Test.Game.PlayPiles
{
    [TestFixture]
    class PileCardTest
    {
        [Test]
        public void testCardForPileIsValid()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();
            PileCard cardForPile = new PileCard(createdDeck[0], (PlayPile)1);

            Assert.True(cardForPile.validatePile(cardForPile.Pile));
        }

        [Test]
        public void testCardForPileIsNotValid()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();
            PileCard cardForPile = new PileCard(createdDeck[0], (PlayPile)88);

            Assert.False(cardForPile.validatePile(cardForPile.Pile));
        }
    }
}
