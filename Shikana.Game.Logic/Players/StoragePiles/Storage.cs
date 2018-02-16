using Shikana.Cards;
using System;
using System.Collections.Generic;

namespace Shikana.Game.Logic.Players.StoragePiles
{
    public class Storage
    {
        public Storage(Card card, Piles pile)
        {
            this.Card = card;
            this.Pile = pile;
        }

        public bool validatePile(Piles pile)
        {
            return Enum.IsDefined(typeof(Piles), pile);
        }


        public Card Card { get; private set; }

        public Piles Pile { get; private set; }
    }
}
