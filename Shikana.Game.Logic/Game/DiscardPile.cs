﻿using System;
using Shikana.Cards;
using System.Collections.Generic;

namespace Shikana.Game.Logic.Game
{
    public class DiscardPile
    {
        public DiscardPile()
        {
            List<Card> cardsForDiscard = new List<Card>();
            this.DiscardedCards = cardsForDiscard;
        }

        public void addCardsToDiscardPile(List<Card> cards)
        {
            this.DiscardedCards.InsertRange(0, cards);
        }

        public List<Card> DiscardedCards { get; private set; }
    }
}
