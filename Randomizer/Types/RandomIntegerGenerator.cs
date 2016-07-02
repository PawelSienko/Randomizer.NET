using System;
using Randomizer.Interfaces.ValueTypes;

// ReSharper disable once CheckNamespace
namespace Randomizer
{
    public class RandomIntegerGenerator : RandomGeneratorBase, IRandomInteger
    {
        public void InitSeed(int seed)
        {
            randomizer = new Random(seed);
        }

        public int GenerateValue()
        {
            if (IsConditionToReachLimit())
            {
                return int.MaxValue;
            }

            return randomizer.Next();
        }

        public int GenerateValue(int min, int max)
        {
            if (min > max)
            {
                throw new ArgumentException("Min cannot be greater than max.");
            }

            if (IsConditionToReachLimit())
            {
                return max;
            }

            return randomizer.Next(min, max);
        }

        public int GeneratePositiveValue()
        {
            if (IsConditionToReachLimit())
            {
                return int.MaxValue;
            }

            return randomizer.Next(0, int.MaxValue);
        }

        public int GenerateNegativeValue()
        {
            if (IsConditionToReachLimit())
            {
                return 0;
            }

            return randomizer.Next(int.MinValue, 0);
        }
    }
}
