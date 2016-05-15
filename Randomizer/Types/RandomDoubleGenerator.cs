using System;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.Types
{
    public class RandomDoubleGenerator : RandomGeneratorBase, IRandomDouble
    {
        public void InitSeed(int seed)
        {
            randomizer = new Random(seed);
        }

        public double GenerateValue()
        {
            double randomDoubleMinValue = randomizer.NextDouble() * double.MaxValue;
            double randomDoubleMaxValue = randomizer.NextDouble() * double.MinValue;
            return randomDoubleMinValue + randomDoubleMaxValue;
        }

        public double GenerateValue(double min, double max)
        {
            if (min >= max)
            {
                throw new ArgumentException(Consts.MinMaxValueExceptionMsg);
            }

            if (IsConditionToReachLimit())
            {
                return double.MaxValue;
            }

            return min + randomizer.NextDouble() * (max - min);
        }

        public double GeneratePositiveValue()
        {
            if (IsConditionToReachLimit())
            {
                return double.MaxValue;
            }

            return this.GenerateValue();
        }

        public double GenerateNegativeValue()
        {
            if (IsConditionToReachLimit())
            {
                return double.MinValue;
            }

            return -this.GenerateValue();
        }
    }
}