using System;
using Shikana.Cards;
using Shikana.Cards.CardEnums;
using System.Collections.Generic;
using System.Linq;

namespace Shikana.Game.Logic.Game.PlayPiles
{
    public class Piles
    {
        public Piles()
        {
            List<PileCard> pile = new List<PileCard>();
            this.CardForPile = pile;
        }

        public void addCardToPile(PileCard cardForPile)
        {
            this.CardForPile.Add(cardForPile);
        }

        public bool checkIfAnyPileHasAKing()
        {
            var piles = this.CardForPile;
            for (var i = 0; i < this.CardForPile.Count; i++)
            {
                var cardForPile = this.CardForPile[i].Card;
                var cardValue = (CardValue)13;

                if (cardForPile.CardValue == cardValue)
                {
                    return true;
                }
            }

            return false;
        }

        public DiscardPile getPileWithAKing(DiscardPile discardPile)
        {
            List<PileCard> cardsInPile = new List<PileCard>();
            for (var i = 0; i < this.CardForPile.Count; i++)
            {
                var cardForPile = this.CardForPile[i].Card;

                var cardValue = (CardValue)(13);

                if (cardForPile.CardValue == cardValue)
                {
                    var pile = this.CardForPile[i].Pile;
                    List<PileCard> cardsFound = this.CardForPile.Where(c => c.Pile == pile).ToList();
                    this.CardForPile.RemoveAll(c => c.Pile == pile);

                    return createDiscardPile(cardsFound, discardPile);
                }
            }

            return null;
        }

        public List<PileCard> CardForPile { get; private set; }

        protected DiscardPile createDiscardPile(List<PileCard> cardsForDiscard, DiscardPile discardPile)
        {
            List<Card> cardsToDiscrad = new List<Card>();

            for (var i = 0; i < cardsForDiscard.Count; i++)
            {
                cardsToDiscrad.Add(cardsForDiscard[i].Card);
            }

            discardPile.addCardsToDiscardPile(cardsToDiscrad);
            return discardPile;
        }
    }
}
