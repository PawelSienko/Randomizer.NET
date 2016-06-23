using System;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.Types
{
    public class RandomLongGenerator : RandomGeneratorBase, IRandomLong
    {
        public void InitSeed(int seed)
        {
            randomizer = new Random(seed);
        }

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

            return min + (long)(randomizer.NextDouble() * (max - min));
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
