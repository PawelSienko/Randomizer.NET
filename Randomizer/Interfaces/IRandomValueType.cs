namespace Randomizer.Interfaces
{
    public interface IRandomValueType<in TSeed, TType> : IRandom<TSeed>
        where TType : struct
        where TSeed : new()
    {
        TType GenerateValue();

        TType GenerateValue(TType min, TType max);
    }
}
