using System;
using ShuffleCore;

namespace ShuffleConsoleApp
{
    public class Program
    {
        static SimpleLogger logger = new SimpleLogger();

        static void Main(string[] args)
        {
            logger.Log("Creating a list of integers and then shuffling them. This will ensure that the order is random and that all integers are present in the resulting list.");
            var size = GetSizeFromArgs(args);
            GenerateShuffledList(size);
        }

        public static void GenerateShuffledList(int size)
        {
            var deck = new DeckOfContiguousIntegers(size);
            deck.Shuffle();
            logger.Log("Shuffled list:");
            foreach (var card in deck.GetCardEnumerator())
            {
                logger.Log($"{card}");
            }
        }

        public static readonly int DefaultSize = 10000;
        public static int GetSizeFromArgs(string[] args)
        {
            var size = DefaultSize;
            if (args.Length > 0)
            {
                try
                {
                    size = Int32.Parse(args[0]);
                }
                catch (Exception ex)
                {
                    logger.Log($"Couldn't decipher size value of '{args[0]}'.");
                }
            }
            logger.Log($"Proceeding to create random list with {size} integers.");
            return size;
        }
    }
}
