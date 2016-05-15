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

            return min + randomizer.NextDouble() * (max - min);
        }

        public double GeneratePositiveValue()
        {
            return this.GenerateValue();
        }

        public double GenerateNegativeValue()
        {
            return -this.GenerateValue();
        }
    }
}