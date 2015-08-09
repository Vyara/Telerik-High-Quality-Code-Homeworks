namespace Poker.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;


    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void HandToStringShouldReturnACorrectStringValue()
        {
            IList<ICard> cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Spades), new Card(CardFace.Queen, CardSuit.Hearts) };
            var hand = new Hand(cards);
            var expected = "Ace of Spades / Queen of Hearts";
            Assert.AreEqual(expected, hand.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HandShouldThrowAnExceptionWhenTheListOfCardsContainsANullObject()
        {
            IList<ICard> cards = new List<ICard>() { new Card(CardFace.Eight, CardSuit.Spades), null };
            var hand = new Hand(cards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HandShouldThrowAnExceptionWhenTheListOfCardsIsNull()
        {
            IList<ICard> cards = null;
            var hand = new Hand(cards);
        }
    }
}
