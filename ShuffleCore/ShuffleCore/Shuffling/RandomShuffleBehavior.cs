using System;
using ShuffleCore.Shuffling;

namespace ShuffleCore
{
    public class RandomShuffleBehavior : IShuffleBehavior
    {
        private readonly Random randomizer;

        public RandomShuffleBehavior() : this ((int)DateTime.Now.Ticks % Int32.MaxValue)
        { 
        }

        // Allow seed injecgtion to give known but arbitrary test results
        public RandomShuffleBehavior(int seed)
        {
            randomizer = new Random(seed);
        }

        // we are asked for random integers from 1-10000, but then told that all the numbers
        // need to be in the final list. So we aren't really generating random numbers, but a random
        // ordering. Shuffling is the effecient way to do that 

        // note: shuffling is destructive in that it corrupts the original list
        //       this is probably okay with the current requirements. The original list order has no value right now
        public void Shuffle<T>(T[] cards)
        {
            T swap;
            for (int index = 0; index < cards.Length; index++)
            {
                var swapWithPosition = randomizer.Next(cards.Length);

                swap = cards[index];
                cards[index] = cards[swapWithPosition];
                cards[swapWithPosition] = swap;
            }
        }
    }
}