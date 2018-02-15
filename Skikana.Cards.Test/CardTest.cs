using System;
using NUnit.Framework;
using Skikana.Cards.CardEnums;

namespace Skikana.Cards.Test
{
    [TestFixture]
    public class CardTest
    {
        [Test]
        public void cardIsValid()
        {
            Card card = new Card((CardSuite)1, (CardValue)3);
            Assert.True(card.validateCard());
        }

        [Test]
        public void cardIsNotValid()
        {
            Card card = new Card((CardSuite)5, (CardValue)8);
            Assert.False(card.validateCard());
        }
    }
}
