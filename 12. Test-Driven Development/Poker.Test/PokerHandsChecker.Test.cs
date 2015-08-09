namespace Poker.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class PokerHandCheckerTest
    {
        [TestMethod]
        public void IsValidHandShouldReturnAValidHand()
        {
            var pokerChecker = new PokerHandsChecker();
            var cards = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Spades), 
                new Card(CardFace.Two, CardSuit.Clubs), 
                new Card(CardFace.Eight, CardSuit.Hearts), 
                new Card(CardFace.Queen, CardSuit.Clubs), 
                new Card(CardFace.Four, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);
            pokerChecker.IsValidHand(hand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsValidHandShouldReturnFalseWhenGivenFiveCardsOfTheSameFace()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard>
            { 
                new Card(CardFace.Jack, CardSuit.Spades), 
                new Card(CardFace.Jack, CardSuit.Clubs), 
                new Card(CardFace.Jack, CardSuit.Hearts), 
                new Card(CardFace.Jack, CardSuit.Clubs), 
                new Card(CardFace.Jack, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsValidHandShouldReturnFalseWhenGivenFiveCardsOfTheSameSuit()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard>
            { 
                new Card(CardFace.Jack, CardSuit.Spades), 
                new Card(CardFace.Jack, CardSuit.Spades), 
                new Card(CardFace.Jack, CardSuit.Spades), 
                new Card(CardFace.Jack, CardSuit.Spades), 
                new Card(CardFace.Jack, CardSuit.Spades) 
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsValidHand(hand));
        }


        [TestMethod]

        [ExpectedException(typeof(ArgumentException))]
        public void IsValidHandShouldReturnFalseWithTwoEqualCards()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard>
            { 
                new Card(CardFace.Jack, CardSuit.Spades), 
                new Card(CardFace.Two, CardSuit.Clubs), 
                new Card(CardFace.Eight, CardSuit.Hearts), 
                new Card(CardFace.Eight, CardSuit.Hearts), 
                new Card(CardFace.Four, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            checker.IsValidHand(hand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsValidHandShouldThrowException_FiveOfAKind()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            {
               new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds), 
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts), 
                new Card(CardFace.Three, CardSuit.Spades) 
            };
            var hand = new Hand(cards);

            checker.IsValidHand(hand);
        }

        [TestMethod]
        public void IsFlushShouldReturnTrueWhenAllCardsAreOfSameSuit()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Jack, CardSuit.Hearts), 
                new Card(CardFace.Two, CardSuit.Hearts), 
                new Card(CardFace.Seven, CardSuit.Hearts), 
                new Card(CardFace.Eight, CardSuit.Hearts), 
                new Card(CardFace.Four, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        public void IsFlushShouldReturnFalseWhenThereIsAStraightFlush()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds), 
                new Card(CardFace.Two, CardSuit.Diamonds), 
                new Card(CardFace.Three, CardSuit.Diamonds), 
                new Card(CardFace.Four, CardSuit.Diamonds), 
                new Card(CardFace.Five, CardSuit.Diamonds) 
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsFlush(hand));
        }

        [TestMethod]
        public void IsFlushShouldReturnFalseWhenHandCardsAreNotOfTheSameSuit()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                 new Card(CardFace.Jack, CardSuit.Hearts), 
                new Card(CardFace.Two, CardSuit.Spades), 
                new Card(CardFace.Seven, CardSuit.Hearts), 
                new Card(CardFace.Eight, CardSuit.Hearts), 
                new Card(CardFace.Four, CardSuit.Hearts) 

            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsFlush(hand));
        }

        [TestMethod]
        public void IsFourOfAKindShouldReturnTrueWhenGivenACorrectValue()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds), 
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts), 
                new Card(CardFace.Three, CardSuit.Spades) 
            };
            var hand = new Hand(cards);

            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFourOfAKindShouldThrowException_FiveOfAKind()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
               new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds), 
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts), 
                new Card(CardFace.Three, CardSuit.Spades) 
            };
            var hand = new Hand(cards);

            checker.IsFourOfAKind(hand);
        }

        [TestMethod]
        public void IsFourOfAKindShouldReturnFalseWhenNotFourCardsWithTheSameFace_ThreeOfAKind()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds), 
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Clubs), 
                new Card(CardFace.Six, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void IsFourOfAKindShouldReturnFalseWhenNotFourCardsWithTheSameFac_TwoPairs()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard>
            { 
                new Card(CardFace.Queen, CardSuit.Spades), 
                new Card(CardFace.Queen, CardSuit.Diamonds), 
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs), 
                new Card(CardFace.Four, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }




    }
}
