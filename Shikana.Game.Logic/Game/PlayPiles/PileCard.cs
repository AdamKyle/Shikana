using Shikana.Cards;
using System;

namespace Shikana.Game.Logic.Game.PlayPiles
{
    public class PileCard
    {
        public PileCard(Card card, PlayPile pile)
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
