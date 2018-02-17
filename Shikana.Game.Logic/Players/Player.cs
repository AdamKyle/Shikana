using System;
using Shikana.Game.Logic.Players.StoragePiles;
using Shikana.Cards;
using Shikana.Cards.CardEnums;
using System.Collections.Generic;
using System.Linq;

namespace Shikana.Game.Logic.Players
{
    public class Player
    {
        public Player()
        {
            this.Storage = new Storage();
        }
        public void playersHand(List<Card> cards)
        {
            this.Hand = cards;
        }

        public void playPile(List<Card> cards)
        {
            this.PlayPileTopCard = cards.GetRange(0, 1);
            cards.RemoveRange(0, 1);
            this.PlayPile = cards;
        }

        public void addCardToTopCard(Card card)
        {
            Card topCardFromTopPile = this.PlayPileTopCard[0];
            int topCardValue = (int)topCardFromTopPile.CardValue;
            int cardValue = (int)card.CardValue;

            // Card being placed on top must be one higher then card currently on top, eg: topCard 8, card being placed 9
            if ((topCardValue - cardValue == -1) && !Enum.IsDefined(typeof(Joker), card.Joker))
            {
                this.PlayPileTopCard.Insert(0, card);
            }
            else
            {
                throw new Exception("Card value is not higher then top card value. Card also cannot be a joker.");
            }
        }

        public Card getTopCard()
        {
            Card card;

            if (this.PlayPileTopCard.Count > 1)
            {
                card = this.PlayPileTopCard[0];
                this.PlayPileTopCard.Remove(card);
            }
            else
            {
                card = this.PlayPileTopCard[0];
                this.PlayPileTopCard.Remove(card);

                if (this.PlayPile.Count > 0)
                {
                    this.PlayPileTopCard = this.PlayPile.GetRange(0, 1);
                    this.PlayPile.RemoveRange(0, 1);
                }
            }

            return card;
        }

        public Card getFromHand(int index)
        {
            if (this.Hand.Any())
            {
                Card card = this.Hand[index];
                this.Hand.RemoveAt(index);

                return card;

            }

            return null;
        }

        public bool hasToDraw()
        {
            return this.Hand.Count < 5;
        }

        public bool hasNoCardsLeftInHand()
        {
            return !this.Hand.Any();
        }

        public bool hasWon()
        {
            return this.PlayPile.Count == 0 && this.PlayPileTopCard.Count == 0;
        }

        public void storeCard(Card card, Piles pile)
        {
            this.Storage.addCardToPile(card, pile);
        }

        public List<Card> Hand { get; private set; }

        public List<Card> PlayPile { get; private set; }

        public List<Card> PlayPileTopCard { get; private set; }

        public Storage Storage { get; private set; }
    }
}
