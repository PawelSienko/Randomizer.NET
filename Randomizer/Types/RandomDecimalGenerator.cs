using System;
using Randomizer.Interfaces;

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
            decimal baseValue = randomizer.Next();
            decimal divider = randomizer.Next();
            return baseValue / divider;
        }

        public decimal GenerateValue(decimal min, decimal max)
        {
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