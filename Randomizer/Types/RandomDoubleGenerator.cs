using System;
using Randomizer.Interfaces.ValueTypes;

// ReSharper disable once CheckNamespace
namespace Randomizer
{
    public class RandomDoubleGenerator : RandomGeneratorBase, IRandomDouble
    {
        public void InitSeed(int seed)
        {
            randomizer = new Random(seed);
        }

        public double GenerateValue()
        {
            double randomPositive = randomizer.NextDouble() * double.MaxValue;
            double randomNegative = randomizer.NextDouble() * double.MinValue;
            return randomPositive + randomNegative;
        }

        public double GenerateValue(double min, double max)
        {
            if (min >= max)
            {
                throw new ArgumentException(Consts.MinMaxValueExceptionMsg);
            }

            if (IsConditionToReachLimit())
            {
                return max;
            }

            return min + randomizer.NextDouble() * (max - min);
        }

        public double GeneratePositiveValue()
        {
            if (IsConditionToReachLimit())
            {
                return double.MaxValue;
            }

            return randomizer.NextDouble() * double.MaxValue;
        }

        public double GenerateNegativeValue()
        {
            if (IsConditionToReachLimit())
            {
                return double.MinValue;
            }

            return randomizer.NextDouble() * double.MinValue;
        }
    }
}