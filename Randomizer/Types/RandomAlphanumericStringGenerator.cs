using System;
using System.Linq;
using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.Types
{
    public class RandomAlphanumericStringGenerator : RandomGeneratorBase, IRandomAlphanumericString
    {
        public RandomAlphanumericStringGenerator()
        {
            randomizer = new Random((int)DateTime.Now.Ticks);
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
            char[] chars = Enumerable.Repeat((char)randomizer.Next(0, source.Length - 1), lenght).ToArray();
            return new string(chars);
        }
    }
}
