using System;
using System.Linq;
using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.Types
{
    public class RandomStringGenerator : RandomStringGeneratorBase, IRandomString
    {
        public RandomStringGenerator()
        {
        }

        public RandomStringGenerator(int seed)
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

            return GenerateStringValue(Consts.FirstCharacterHex, Consts.LastCharacterHex, length);
        }

        public string GenerateLowerCaseValue(int length = 25)
        {
            if (length <= 0)
            {
                throw new ArgumentException();
            }

            var randomString = GenerateStringValue(Consts.FirstCharacterHex, Consts.LastCharacterHex, length);
            return randomString.ToLower();
        }

        public string GenerateUpperCaseValue(int length = 25)
        {
            if (length <= 0)
            {
                throw new ArgumentException();
            }

            var randomString = GenerateStringValue(Consts.FirstCharacterHex, Consts.LastCharacterHex, length);
            return randomString.ToUpper();
        }

        public string GenerateApartFrom(int length = 25, params char[] excluded)
        {
            if (length <= 0 || excluded == null || excluded.Length == 0)
            {
                throw new ArgumentException();
            }

            var charsAsInt = excluded.Select(item => (int) item);
            var randomString = GenerateStringValue(Consts.FirstCharacterHex, Consts.LastCharacterHex, length, charsAsInt.ToArray());
            return randomString;
        }

        protected override string GetRandomValue()
        {
            return GenerateStringValue(Consts.FirstCharacterHex, Consts.LastCharacterHex);
        }
    }
}
