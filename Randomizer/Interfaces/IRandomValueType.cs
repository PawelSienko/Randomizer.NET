namespace Randomizer.Interfaces
{
    public interface IRandomValueType<TType> : IRandom
        where TType : struct
    {
        TType GenerateValue();

        TType GenerateValue(TType min, TType max);

        TType GenerateValue(params TType[] values);
    }
}
