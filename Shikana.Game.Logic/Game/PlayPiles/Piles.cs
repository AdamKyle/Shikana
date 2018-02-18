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
            this.PlayPiles = new List<List<Card>>();

            // Eight Play piles
            this.PlayPiles.Add(new List<Card>());
            this.PlayPiles.Add(new List<Card>());
            this.PlayPiles.Add(new List<Card>());
            this.PlayPiles.Add(new List<Card>());
            this.PlayPiles.Add(new List<Card>());
            this.PlayPiles.Add(new List<Card>());
            this.PlayPiles.Add(new List<Card>());
            this.PlayPiles.Add(new List<Card>());

        }

        public void addCardToPile(Card card, PlayablePiles pile)
        {
            if (validatePile(pile))
            {
                var cards = this.PlayPiles[(int)pile];

                if (cards.Count > 0)
                {
                    addCardToExistingPile(card, cards);
                } else
                {
                    startAPlayPile(card, cards);
                }
            } else
            {
                throw new InvalidPlayPileException((int)pile);
            }
        }

        public bool validatePile(PlayablePiles pile)
        {
            return Enum.IsDefined(typeof(PlayablePiles), pile);
        }

        public bool checkIfAnyPileHasAKing()
        {
            for (var i = 0; i < this.PlayPiles.Count; i++)
            {
                for (var j = 0; j < this.PlayPiles[i].Count; j++)
                {
                    var cardForPile = this.PlayPiles[i][j];
                    var cardValue = (CardValue)13;

                    if (cardForPile.CardValue == cardValue)
                    {
                        return true;
                    }
                }

            }

            return false;
        }

        public DiscardPile getPileWithAKing(DiscardPile discardPile)
        {
            for (var i = 0; i < this.PlayPiles.Count; i++)
            {
                for (var j = 0; j < this.PlayPiles[i].Count; j++)
                {
                    Card cardForPile = this.PlayPiles[i][j];

                    if (cardForPile.CardValue == (CardValue)13)
                    {
                        var cardsFound = this.PlayPiles[i].GetRange(0, 13);
                        this.PlayPiles[i].Clear();

                        return createDiscardPile(cardsFound, discardPile);
                    }
                }
                
            }

            return null;
        }

        public List<List<Card>> PlayPiles { get; private set; }

        protected DiscardPile createDiscardPile(List<Card> cardsForDiscard, DiscardPile discardPile)
        {
            List<Card> cardsToDiscrad = new List<Card>();

            for (var i = 0; i < cardsForDiscard.Count; i++)
            {
                cardsToDiscrad.Add(cardsForDiscard[i]);
            }

            discardPile.addCardsToDiscardPile(cardsToDiscrad);
            return discardPile;
        }

        protected void addCardToExistingPile(Card card, List<Card> cards)
        {
            if ((int)card.CardValue - (int)cards[cards.Count - 1].CardValue == 1)
            {
                cards.Add(card);
            }
            else
            {
                throw new InvalidCardValueSizeDifferenceException(card, cards[cards.Count - 1]);
            }
        }

        protected void startAPlayPile(Card card, List<Card> cards)
        {
            if (card.CardValue == (CardValue)1)
            {
                cards.Add(card);
            }
            else
            {
                throw new MustBeAnAceException(card);
            }
        }
    }
}
