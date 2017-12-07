using NUnit.Framework;
using ShuffleConsoleApp;

namespace ShuffleTest
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void CanReadASizeValue()
        {
            var size = Program.GetSizeFromArgs(new[] {"3"});

            Assert.Contains("Proceeding to create random list with 3 integers.", SimpleLogger.logStatements);
            Assert.AreEqual(3, size);
        }

        [Test]
        public void UsesDefaultValueWhenNoSizeInArgs()
        {
            var size = Program.GetSizeFromArgs(new string[0]);
            Assert.Contains($"Proceeding to create random list with {Program.DefaultSize} integers.", SimpleLogger.logStatements);
            Assert.AreEqual(Program.DefaultSize, size);
        }

        [Test]
        public void UsesDefaultValueWhenNoSizeNan()
        {
            var size = Program.GetSizeFromArgs(new [] {"foo"});
            Assert.Contains($"Couldn't decipher size value of 'foo'.", SimpleLogger.logStatements);
            Assert.Contains($"Proceeding to create random list with {Program.DefaultSize} integers.", SimpleLogger.logStatements);
            Assert.AreEqual(Program.DefaultSize, size);
        }

        [Test]
        public void ShouldGeneerateShuffledList()
        {
            Program.GenerateShuffledList(3);
            Assert.Contains("Shuffled list:", SimpleLogger.logStatements);
            // not overly worried about order as that should be tested elsewhere but do want to see all the lines
            Assert.Contains("1", SimpleLogger.logStatements);
            Assert.Contains("2", SimpleLogger.logStatements);
            Assert.Contains("3", SimpleLogger.logStatements);

        }
    }
}
