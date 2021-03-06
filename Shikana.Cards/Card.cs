﻿using Shikana.Cards.CardEnums;
using System;
using System.Collections.Generic;

namespace Shikana.Cards
{
    public class Card
    {
        public Card(CardSuite cardSuite, CardValue cardValue)
        {
            this.CardValue = cardValue;
            this.CardSuite = cardSuite;
        }

        public Card(Joker joker)
        {
            this.Joker = joker;
        }

        public CardSuite CardSuite { get; private set; }

        public CardValue CardValue { get; private set; }

        public Joker Joker { get; private set; }

        public bool validateCard()
        {
            return validateCardValue(this.CardValue) && validateSuite(this.CardSuite);
        }

        protected bool validateSuite(CardSuite suite)
        {
            return Enum.IsDefined(typeof(CardSuite), suite);
        }

        protected bool validateCardValue(CardValue value)
        {
            return Enum.IsDefined(typeof(CardValue), value);
        }

        public static implicit operator Card(List<List<Card>> v)
        {
            throw new NotImplementedException();
        }
    }
}
