namespace Randomizer.Interfaces
{
    public interface IRandomDigit<TType>
        : IRandomValueType<TType>
        where TType : struct
    {
        TType GeneratePositiveValue();

        TType GenerateNegativeValue();
    }
}
