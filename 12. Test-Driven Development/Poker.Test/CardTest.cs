namespace Poker.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CardToStringShouldReturnACorrectStringValue()
        {
            var card = new Card(CardFace.Ace, CardSuit.Spades);
            var expected = "Ace of Spades";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void CardShouldCompareCorrectly_DifferentCards()
        {
            var firstCard = new Card(CardFace.Ace, CardSuit.Spades);
            var secondCard = new Card(CardFace.Nine, CardSuit.Clubs);

            Assert.IsFalse(firstCard.Equals(secondCard));
        }

        [TestMethod]
        public void CardShouldCompareCorrectly_EqualCard()
        {
            var firstCard = new Card(CardFace.Queen, CardSuit.Spades);
            var secondCard = new Card(CardFace.Queen, CardSuit.Spades);

            Assert.IsTrue(firstCard.Equals(secondCard));
        }
    }
}
