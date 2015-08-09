namespace Poker
{
    using System;
    using System.Collections.Generic;

    public class Hand : IHand
    {

        public Hand(IList<ICard> cards)
        {
            Validator.ObjectValidator.CheckIfNull(cards, "Card list cannot be null");

            foreach (var card in cards)
            {
                Validator.ObjectValidator.CheckIfNull(card, "Card cannot be null");
            }

            this.Cards = cards;
        }

        public enum Type
        {
            HighCard = 0,
            OnePair = 1,
            TwoPairs = 2,
            ThreeOfAKind = 3,
            Straight = 4,
            Flush = 5,
            FullHouse = 6,
            FourOfAKind = 7,
            StraightFlush = 8
        }

        public IList<ICard> Cards { get; private set; }

        public override string ToString()
        {
            return string.Join(" / ", this.Cards);
        }
    }
}
