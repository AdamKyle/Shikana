using Shikana.Cards;
using System;
using System.Collections.Generic;

namespace Shikana.Game.Logic.Players.StoragePiles
{
    public class Storage
    {

        public Storage()
        {
            this.Pile = new List<List<Card>>();

            // Four Piles for storage
            this.Pile.Add(new List<Card>());
            this.Pile.Add(new List<Card>());
            this.Pile.Add(new List<Card>());
            this.Pile.Add(new List<Card>());
        }

        public void addCardToPile(Card card, Piles pile)
        {
            if (validatePile(pile))
            {
                int index = (int)pile;
                this.Pile[index].Add(card);
            } else
            {
                throw new InvalidStoragePileException((int)pile);
            }

        }

        public bool validatePile(Piles pile)
        {
            return Enum.IsDefined(typeof(Piles), pile);
        }


        public Card Card { get; private set; }

        public List<List<Card>> Pile { get; private set; }
    }
}
