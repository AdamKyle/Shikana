using NUnit.Framework;
using Shikana.Cards;
using Shikana.Game.Logic.Players.StoragePiles;

namespace Shikana.Game.Logic.Test.Players.StoragePiles
{
    [TestFixture]
    class StorageTest
    {
        [Test]
        public void testCardForPileIsValid()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();
            Storage cardForPile = new Storage(createdDeck[0], (Piles)1);

            Assert.True(cardForPile.validatePile(cardForPile.Pile));
        }

        [Test]
        public void testCardForPileIsNotValid()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();
            Storage cardForPile = new Storage(createdDeck[0], (Piles)88);

            Assert.False(cardForPile.validatePile(cardForPile.Pile));
        }
    }
}
