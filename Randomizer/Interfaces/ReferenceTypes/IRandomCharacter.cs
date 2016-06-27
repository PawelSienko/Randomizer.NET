namespace Randomizer.Interfaces.ReferenceTypes
{
    public interface IRandomCharacter : IRandomRefType<char>
    {
        char GenerateValue(char min, char max);
    }
}
