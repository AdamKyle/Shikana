# Shikana

![](https://travis-ci.org/AdamKyle/Shikana.svg?branch=master)

The core aspect of this project is to teach my self C# and create a game called
Shikana, which is a card game, the UI will be very basic but the underlying logic
and structure is what we are after here.

## Shikana.Cards

Deals with defining and building a card as well as defining and building as well
as shuffling and merging of decks.

A deck is nothing more then a set of cards.

Each deck comes with two jokers. Making a total of 54 cards.

### Shikana.Cards.Test

A series of tests to run for the cards.

## Shikana.Game.logic

This library is responsible for containing all the game logic for the game
of Shikana. This includes Players, PlayPiles, StoragePiles, Dealing and the
Discard Pile.
