namespace Poker
{
    using System;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public const int ValidCardsNumber = 5;

        public bool IsValidHand(IHand hand)
        {
            Validator.ObjectValidator.CheckIfNull(hand, "Hand cannot be null.");

            if (hand.Cards.Count != ValidCardsNumber)
            {
                throw new ArgumentException("Invalid hand.");
            }

            if (hand.Cards.Distinct().Count() != ValidCardsNumber)
            {
                throw new ArgumentException("Duplicate cards.");
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            var isStraight = true;

            var sorted = hand.Cards.Select(value => (int)value.Face).OrderBy(value => value).ToArray();

            if (sorted.Contains((int)CardFace.Ace) && sorted.Contains((int)CardFace.Two))
            {
                var index = Array.IndexOf(sorted, (int)CardFace.Ace);
                sorted[index] = 1;
                sorted = sorted.OrderBy(value => value).ToArray();
            }

            for (int ind = 0; ind < sorted.Length - 1; ind++)
            {
                if (sorted[ind] + 1 != sorted[ind + 1])
                {
                    isStraight = false;
                    break;
                }
            }

            bool isFlush = hand.Cards.GroupBy(card => card.Suit).Count() == 1;

            return isStraight && isFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var group = hand.Cards.GroupBy(card => card.Face);
            return group.Any(gr => gr.Count() == 4);
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            return hand.Cards.GroupBy(card => card.Suit).Count() == 1 && !this.IsStraightFlush(hand);
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
