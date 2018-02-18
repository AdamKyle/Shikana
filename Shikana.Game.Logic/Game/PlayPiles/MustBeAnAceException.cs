using Shikana.Cards;
using System;

namespace Shikana.Game.Logic.Game.PlayPiles
{
    public class MustBeAnAceException : Exception
    {
        public MustBeAnAceException(Card card): base(String.Format("Card with value {0} is not an Ace. Initial card must be an Ace.", card.CardValue))
        {

        }
    }
}
