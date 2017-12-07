namespace ShuffleCore.Shuffling
{
    public interface IShuffleBehavior
    {
        void Shuffle<T>(T[] cards);
    }
}