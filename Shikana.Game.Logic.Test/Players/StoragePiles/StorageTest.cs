using NUnit.Framework;
using Shikana.Cards;
using Shikana.Cards.CardEnums;
using Shikana.Game.Logic.Players.StoragePiles;

namespace Shikana.Game.Logic.Test.Players.StoragePiles
{
    [TestFixture]
    class StorageTest
    {
        [Test]
        public void addCardToStorage()
        {
            Card card = new Card((CardSuite)1, (CardValue)1);
            Storage storage = new Storage();
            storage.addCardToPile(card, (Piles)0);

            Assert.AreEqual(1, storage.Pile[0].Count);
            Assert.AreEqual(card.CardValue, storage.Pile[0][0].CardValue);
        }

        [Test]
        public void invalidStoragePile()
        {
            void invalidPile()
            {
                Card card = new Card((CardSuite)1, (CardValue)1);
                Storage storage = new Storage();
                storage.addCardToPile(card, (Piles)999);

            }

            Assert.Throws(typeof(InvalidStoragePileException), invalidPile);
        }

        [Test]
        public void testCardForPileIsValid()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();
            Storage cardForPile = new Storage();

            Assert.True(cardForPile.validatePile((Piles)1));
        }

        [Test]
        public void testCardForPileIsNotValid()
        {
            Deck deck = new Deck();
            var createdDeck = deck.createDeck();
            Storage cardForPile = new Storage();

            Assert.False(cardForPile.validatePile((Piles)33));
        }
    }
}
