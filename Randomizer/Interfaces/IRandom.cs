namespace Randomizer.Interfaces
{
    public interface IRandom<in TSeed>
        where TSeed : new()
    {
        void InitSeed(TSeed seed);
    }
}
