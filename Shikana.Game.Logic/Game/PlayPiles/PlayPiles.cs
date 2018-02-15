using System;
using Skikana.Cards;
using Skikana.Cards.CardEnums;
using System.Collections.Generic;
using System.Linq;

namespace Shikana.Game.Logic.Game.PlayPiles
{
    class PlayPiles
    {
        public PlayPiles()
        {
            List<CardForPile> pile = new List<CardForPile>();
            this.CardForPile = pile;
        }

        public void addCardToPile(CardForPile cardForPile)
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
            List<CardForPile> cardsInPile = new List<CardForPile>();
            for (var i = 0; i < this.CardForPile.Count; i++)
            {
                var cardForPile = this.CardForPile[i].Card;

                var cardValue = (CardValue)(13);

                if (cardForPile.CardValue == cardValue)
                {
                    var pile = this.CardForPile[i].Pile;
                    List<CardForPile> cardsFound = this.CardForPile.Where(c => c.Pile == pile).ToList();
                    this.CardForPile.RemoveAll(c => c.Pile == pile);

                    return createDiscardPile(cardsFound, discardPile);
                }
            }

            return null;
        }

        public List<CardForPile> CardForPile { get; private set; }

        protected DiscardPile createDiscardPile(List<CardForPile> cardsForDiscard, DiscardPile discardPile)
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
