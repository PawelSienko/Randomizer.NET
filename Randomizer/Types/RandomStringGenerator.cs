using System.Linq;
using Common.Core.Validation;
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
            return GenerateStringValue(Consts.FirstCharacterHex, Consts.LastCharacterHex);
        }

        public string GenerateValue(int length)
        {
            Validator.ValidateCondition(length, (item) => item > 0);

            return GenerateStringValue(Consts.FirstCharacterHex, Consts.LastCharacterHex, length);
        }

        public string GenerateLowerCaseValue(int length = 25)
        {
            Validator.ValidateCondition(length, (item) => item > 0);

            var randomString = GenerateStringValue(Consts.FirstCharacterHex, Consts.LastCharacterHex, length);
            return randomString.ToLower();
        }

        public string GenerateUpperCaseValue(int length = 25)
        {
            Validator.ValidateCondition(length, (item) => item > 0);

            var randomString = GenerateStringValue(Consts.FirstCharacterHex, Consts.LastCharacterHex, length);
            return randomString.ToUpper();
        }

        public string GenerateValueWithout(int length = 25, params char[] excluded)
        {
            Validator.ValidateCondition(length, (item) => item > 0);
            Validator.ValidateNull(excluded);
            Validator.ValidateCondition(excluded, item => item.Length > 0);

            var charsAsInt = excluded.Select(item => (int) item);
            var randomString = GenerateStringValue(Consts.FirstCharacterHex, Consts.LastCharacterHex, length, charsAsInt.ToArray());
            return randomString;
        }
    }
}
