using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ShuffleCore.Shuffling;

namespace ShuffleCore
{
    public class DeckOfContiguousIntegers
    {
        private readonly int[] cards;
        private readonly IShuffleBehavior _shuffleBehavior;


        // shuffling behavior is likely to change and could be difficult to test, 
        // so a good candidated for dependency injection.
        // I don't want to complicate things with a DI framework though, so I'll just
        // do the simplest DI
        public DeckOfContiguousIntegers(int size) : this(size, new RandomShuffleBehavior())
        {}

        public DeckOfContiguousIntegers(int size, IShuffleBehavior shuffleBehavior)
        {
            cards = new int[size];
            for (int index = 0; index < size; index++)
            {
                cards[index] = index + 1;
            }

            _shuffleBehavior = shuffleBehavior;
        }

        public IEnumerable<int> GetCardEnumerator()
        {
            return cards.AsEnumerable();
        }

        public void Shuffle()
        {
            _shuffleBehavior.Shuffle(cards);
        }
    }
}
