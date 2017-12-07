using NUnit.Framework;
using NUnit.Framework.Internal;
using ShuffleCore;

namespace ShuffleTest.Shuffling
{
    [TestFixture]
    public class RandomShufflingBehaviorTests
    {
        [Test]
        public void ShouldUseSeedToRandomizeArray()
        {
            var someThings = new [] {"a", "b", "c", "d"};
            int seed = 17;
            var expectedResultWithSeed = new[] {"b", "d", "a", "c"};
            var shuffler = new RandomShuffleBehavior(seed);
            shuffler.Shuffle(someThings);

            Assert.AreEqual(expectedResultWithSeed, someThings);
        }
    }
}
