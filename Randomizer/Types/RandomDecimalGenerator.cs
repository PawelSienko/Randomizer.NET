using System;
using Randomizer.Interfaces.ValueTypes;

// ReSharper disable once CheckNamespace
namespace Randomizer
{
    public class RandomDecimalGenerator : RandomGeneratorBase, IRandomDecimal
    {
        public void InitSeed(int seed)
        {
            randomizer = new Random(seed);
        }

        public decimal GenerateValue()
        {
            decimal randomPositive = (decimal)randomizer.NextDouble() * decimal.MaxValue;
            decimal randomNegative = (decimal)randomizer.NextDouble() * decimal.MinValue;
            if (IsConditionToReachLimit())
            {
                return decimal.MaxValue;
            }

            return randomNegative + randomPositive;
        }

        public decimal GenerateValue(decimal min, decimal max)
        {
            if (min >= max)
            {
                throw new ArgumentException(Consts.MinMaxValueExceptionMsg);
            }

            if (IsConditionToReachLimit())
            {
                return max;
            }

            return min + (decimal)randomizer.NextDouble() * (max - min);
        }

        public decimal GeneratePositiveValue()
        {
            if (IsConditionToReachLimit())
            {
                return decimal.MaxValue;
            }

            return (decimal)randomizer.NextDouble() * decimal.MaxValue;
        }

        public decimal GenerateNegativeValue()
        {
            if (IsConditionToReachLimit())
            {
                return decimal.MinValue;
            }

            return (decimal)randomizer.NextDouble() * decimal.MinValue;
        }
    }
}