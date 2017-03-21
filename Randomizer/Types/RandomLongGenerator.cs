using System;
using Randomizer.Interfaces.ValueTypes;

// ReSharper disable once CheckNamespace
namespace Randomizer
{
    public class RandomLongGenerator : RandomGenericGeneratorBase<long>, IRandomLong
    {
        public RandomLongGenerator()
        {

        }
        public RandomLongGenerator(int seed)
            : base(seed)
        { }

        public long GenerateValue()
        {
            long randomPositive = (long)(randomizer.NextDouble() * long.MaxValue);
            long randomNegative = (long)(randomizer.NextDouble() * long.MinValue);
            if (IsConditionToReachLimit())
            {
                return long.MaxValue;
            }

            return randomNegative + randomPositive;
        }

        public long GenerateValue(long min, long max)
        {
            if (min >= max)
            {
                throw new ArgumentException(Consts.MinMaxValueExceptionMsg);
            }

            if (IsConditionToReachLimit())
            {
                return max;
            }
            long randomLong = (long)randomizer.NextDouble();
            return min + randomLong * max - randomLong * min;
        }

        public long GeneratePositiveValue()
        {
            if (IsConditionToReachLimit())
            {
                return long.MaxValue;
            }

            return (long)(randomizer.NextDouble() * long.MaxValue);
        }

        public long GenerateNegativeValue()
        {
            if (IsConditionToReachLimit())
            {
                return long.MinValue;
            }

            return (long)(randomizer.NextDouble() * long.MinValue);
        }
    }
}
