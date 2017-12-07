using System;
using NUnit.Framework;
using ShuffleCore;
using System.Linq;

namespace ShuffleTest
{
    [TestFixture]
    public class DeckOfContiguousIntegersTests
    {
        [Test]
        public void ShouldSetupDeckWithContiguousIntegers()
        {
            var size = 5;
            var deck = new DeckOfContiguousIntegers(size);
            var expectedUnshuffledCards = new[] {1, 2, 3, 4, 5};

            var cardsAsArray = deck.GetCardEnumerator().ToArray();
            
            Assert.AreEqual(expectedUnshuffledCards, cardsAsArray);
        }

        [Test]
        public void ShouldShuffle()
        {
            var size = 5;
            var seed = 49;
            var deck = new DeckOfContiguousIntegers(size, new RandomShuffleBehavior(seed));
            var expectedDeckAfterShufflingWithSeed = new[] {4, 5, 1, 3, 2};

            deck.Shuffle();
            var cardsAsArray = deck.GetCardEnumerator().ToArray();
            
            Assert.AreEqual(expectedDeckAfterShufflingWithSeed, cardsAsArray);
        }

        [Test]
        public void ShouldShuffleLargeSetsWithoutDataLoss()
        {
            var size = 100;
            var deck = new DeckOfContiguousIntegers(size);
            
            deck.Shuffle();
            var cardsAsArray = deck.GetCardEnumerator().ToArray();

            for (int i = 0; i < size; i++)
            {
                Assert.Contains(i+1, cardsAsArray);
            }
        }

        [Test]
        public void ShouldShuffleLargeSetsQuicklyAndWithoutOrder()
        {
            var size = 10000;
            var deck = new DeckOfContiguousIntegers(size);
            var sortedOrder = deck.GetCardEnumerator().ToArray();

            var shuffleStarted = DateTime.Now;
            deck.Shuffle();
            var shuffleFinished = DateTime.Now;
            Assert.Greater(TimeSpan.FromSeconds(.1), shuffleFinished - shuffleStarted);

            var currentOrder = deck.GetCardEnumerator().ToArray();
            Assert.AreNotEqual(sortedOrder, currentOrder);
        }
    }
}
