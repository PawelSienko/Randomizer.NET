using System;
using System.Collections.Generic;
using System.Linq;
using Common.Core.Validation;
using Randomizer.Interfaces.ReferenceTypes;

// ReSharper disable once CheckNamespace
namespace Randomizer
{
    public class RandomAlphanumericStringGenerator : RandomGeneratorBase, IRandomAlphanumericString
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
            return GenerateRandomString(25, Consts.AlphanumericCharacters.ToCharArray());
        }

        public string GenerateValue(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length cannot be less or equal 0.");
            }

            return GenerateRandomString(length, Consts.AlphanumericCharacters.ToCharArray());
        }

        public string GenerateLowerCaseValue(int length = 25)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length cannot be less or equal 0.");
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

        public string GenerateValueWithout(int length, params char[] excluded)
        {
            Validator.ValidateCondition(length, (item) => item > 0);
            Validator.ValidateNull(excluded);
            Validator.ValidateCondition(excluded, item => item.Length > 0);

            var alphanumericList = Consts.AlphanumericCharArray.ToList();
            var itemsWithoutExcluded = alphanumericList.Except(excluded).ToList();

            return GenerateRandomString(length, itemsWithoutExcluded);
        }
        
        private string GenerateRandomString(int lenght, IList<char> source)
        {
            int maxIndex = source.Count- 1;
            char[] resultArray = new char[lenght];
            char[] sourceAsArray = source.ToArray();

            for (int i = 0; i < lenght; i++)
            {
                var randomIndex = randomizer.Next(0, maxIndex);
                resultArray[i] = sourceAsArray[randomIndex];
            }

            return new string(resultArray);
        }
    }
}
