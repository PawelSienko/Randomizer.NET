using System;
using Randomizer.Interfaces.ValueTypes;

// ReSharper disable once CheckNamespace
namespace Randomizer
{
    public class RandomIntegerGenerator : RandomGenericGeneratorBase<int>, IRandomInteger
    {
        public RandomIntegerGenerator()
        {
            
        }
        public RandomIntegerGenerator(int seed)
            : base(seed)
        { }

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
