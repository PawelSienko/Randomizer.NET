using System;
using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.Types
{
    public class RandomAlphanumericGenerator : RandomGeneratorBase, IRandomCharacter
    {
        public RandomAlphanumericGenerator(int seed)
        {
            randomizer = new Random(seed);
        }

        public char GenerateValue()
        {
            return (char)randomizer.Next(0, Consts.AlphanumericCharacters.Length - 1);
        }

        public char GenerateValue(char min, char max)
        {
            min = min.ToString().ToLower()[0];
            max = max.ToString().ToLower()[0];

            if (min >= max)
            {
                throw new ArgumentException(Consts.MinMaxValueExceptionMsg);
            }

            if (IsConditionToReachLimit())
            {
                return max;
            }

            int firstIndex = Consts.AlphanumericCharacters.IndexOf(min);
            int lastIndex = Consts.AlphanumericCharacters.IndexOf(max);

            return (char)randomizer.Next(firstIndex, lastIndex);
        }
    }
}
