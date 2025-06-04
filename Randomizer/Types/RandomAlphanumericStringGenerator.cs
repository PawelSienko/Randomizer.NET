using System;
using System.Linq;
using Randomizer.Interfaces.ReferenceTypes;

// ReSharper disable once CheckNamespace
namespace Randomizer
{
    public class RandomAlphanumericStringGenerator : RandomStringGeneratorBase, IRandomAlphanumericString
    {
        public RandomAlphanumericStringGenerator()
        {

        }
        public RandomAlphanumericStringGenerator(int seed)
            : base(seed)
        {

        }

        public string GenerateValue()
        {
            return GetRandomValue();
        }

        public string GenerateValue(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException();
            }

            return GenerateRandomString(length, Consts.AlphanumericCharacters.ToCharArray());
        }

        public string GenerateLowerCaseValue(int length = 25)
        {
            if (length <= 0)
            {
                throw new ArgumentException();
            }

            return GenerateRandomString(length, Consts.Lowercase.ToCharArray());
        }

        public string GenerateUpperCaseValue(int length = 25)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length cannot be less or equal 0.");
            }

            return GenerateRandomString(length, Consts.Uppercase.ToCharArray());
        }

        public string GenerateApartFrom(int length, params char[] excluded)
        {
            if (length <= 0 || excluded == null || excluded.Length == 0)
            {
                throw new ArgumentException();
            }

            var alphanumericList = Consts.AlphanumericCharArray.ToList();
            var itemsWithoutExcluded = alphanumericList.Except(excluded).ToList();

            return GenerateRandomString(length, itemsWithoutExcluded);
        }

        protected override string GetRandomValue()
        {
            return GenerateRandomString(25, Consts.AlphanumericCharacters.ToCharArray());
        }
    }
}
