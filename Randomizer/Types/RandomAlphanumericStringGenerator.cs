using System;
using System.Linq;
using Randomizer.Interfaces.ReferenceTypes;

// ReSharper disable once CheckNamespace
namespace Randomizer
{
    public class RandomAlphanumericStringGenerator : RandomGeneratorBase, IRandomAlphanumericString
    {
        public RandomAlphanumericStringGenerator(int seed)
            : base(seed)
        {

        }

        public string GenerateValue()
        {
            return GenerateRandomString(25, Consts.AlphanumericCharacters);
        }

        public string GenerateValue(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length cannot be less or equal 0.");
            }

            return GenerateRandomString(length, Consts.AlphanumericCharacters);
        }

        public string GenerateLowerCaseValue(int length = 25)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length cannot be less or equal 0.");
            }

            return GenerateRandomString(length, Consts.Lowercase);
        }

        public string GenerateUpperCaseValue(int length = 25)
        {

            if (length <= 0)
            {
                throw new ArgumentException("Length cannot be less or equal 0.");
            }

            return GenerateRandomString(length, Consts.Uppercase);
        }

        private string GenerateRandomString(int lenght, string source)
        {
            int maxIndex = source.Length - 1;
            char[] resultArray = new char[lenght];
            char[] sourceAsArray = source.ToCharArray();

            for (int i = 0; i < lenght; i++)
            {
                var randomIndex = randomizer.Next(0, maxIndex);
                resultArray[i] = sourceAsArray[randomIndex];
            }

            return new string(resultArray);
        }
    }
}
