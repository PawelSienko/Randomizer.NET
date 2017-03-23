namespace Randomizer.Interfaces.ReferenceTypes
{
    public interface IRandomAlphanumericString : IRandomRefType<string>
    {
        string GenerateValue(int lenght = 25);

        string GenerateLowerCaseValue(int length = 25);

        string GenerateUpperCaseValue(int length = 25);

        string GenerateApartFrom(int length = 25, params char[] excluded);
    }
}