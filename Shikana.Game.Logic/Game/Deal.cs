using System;
using Shikana.Cards;
using System.Collections.Generic;
using System.Linq;
using Shikana.Game.Logic.Players;

namespace Shikana.Game.Logic.Game
{
    class Deal
    {
        public Deal(List<Card> deck)
        {
            this.Deck = deck;
        }

        public void dealPlayPiles(Player player1, Player player2)
        {
            player1.playPile(this.Deck.GetRange(0, 20));
            this.Deck.RemoveRange(0, 20);

            player2.playPile(this.Deck.GetRange(0, 20));
            this.Deck.RemoveRange(0, 20);

        }

        public void dealPlayersHands(Player player1, Player player2)
        {
            player1.playersHand(this.Deck.GetRange(0, 5));
            this.Deck.RemoveRange(0, 5);

            player2.playersHand(this.Deck.GetRange(0, 5));
            this.Deck.RemoveRange(0, 5);
        }

        public List<Card> drawCards(Player player, DiscardPile discardPile)
        {
            List<Card> cards = new List<Card>();

            if (player.Hand.Count < 5)
            {
                int cardsToDraw = 5 - player.Hand.Count;
                if (doesDeckContainEnoughCards(cardsToDraw))
                {
                    cards = this.Deck.GetRange(0, cardsToDraw);
                    this.Deck.RemoveRange(0, cardsToDraw);
                }
                else
                {
                    Deck deck = new Deck();
                    this.Deck = deck.ShuffleDeck(this.Deck.Concat(discardPile.DiscardedCards).ToList());
                    discardPile.DiscardedCards.Clear();
                    cards = this.Deck.GetRange(0, cardsToDraw);
                    this.Deck.RemoveRange(0, cardsToDraw);

                }

                return cards;
            }

            return null;
        }

        public bool doesDeckContainEnoughCards(int cardsToDraw)
        {
            if (this.Deck.Count <= cardsToDraw)
            {
                return false;
            }

            return true;
        }

        public List<Card> Deck { get; private set; }
    }
}
