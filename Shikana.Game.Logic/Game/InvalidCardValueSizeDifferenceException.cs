using Shikana.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shikana.Game.Logic.Game
{
    public class InvalidCardValueSizeDifferenceException : Exception
    {
        public InvalidCardValueSizeDifferenceException(Card cardBeingPlayed, Card cardOnPile) : 
            base(String.Format("Card with value {0} is not one larger then current card with value {1}. Cannot be played.", cardBeingPlayed.CardValue, cardOnPile.CardValue))
        {

        }
    }
}
