namespace Randomizer.Interfaces
{
    public interface IRandomValueType<TType> : IRandom
        where TType : struct
    {
        TType GenerateValue();

        TType GenerateValue(TType min, TType max);

        TType GenerateValueWithin(params TType[] values);

        TType GenerateValueApartFrom(params TType[] values);
    }
}
