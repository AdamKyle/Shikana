using Shikana.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shikana.Game.Logic.Game.PlayPiles
{
    class CardForPile
    {
        public CardForPile(Card card, PlayPile pile)
        {
            this.Card = card;
            this.Pile = pile;
        }

        public bool validatePile(PlayPile pile)
        {
            return Enum.IsDefined(typeof(PlayPile), pile);
        }

        public Card Card { get; private set; }
        public PlayPile Pile { get; private set; }
    }
}
