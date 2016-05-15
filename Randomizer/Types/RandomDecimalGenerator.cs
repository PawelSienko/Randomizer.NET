using System;
using Randomizer.Interfaces;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.Types
{
    public class RandomDecimalGenerator : RandomGeneratorBase, IRandomDecimal
    {
        public void InitSeed(int seed)
        {
            this.randomizer = new Random(seed);
        }

        public decimal GenerateValue()
        {
            decimal randomDecimalPositive = (decimal)randomizer.NextDouble() * decimal.MaxValue;
            decimal randomDecimalNegative = (decimal)randomizer.NextDouble() * decimal.MinValue;

            return randomDecimalNegative + randomDecimalPositive;
        }

        public decimal GenerateValue(decimal min, decimal max)
        {
            if (min >= max)
            {
                throw new ArgumentException(Consts.MinMaxValueExceptionMsg);
            }

            return min + (decimal)randomizer.NextDouble() * (max - min);
        }

        public decimal GeneratePositiveValue()
        {
            return (decimal)randomizer.NextDouble() * decimal.MaxValue;
        }

        public decimal GenerateNegativeValue()
        {
            return (decimal)randomizer.NextDouble() * decimal.MinValue;
        }
    }
}