using System;
using Randomizer.Interfaces;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.Types
{
    public sealed class RandomFloatGenerator : RandomGeneratorBase, IRandomFloat
    {
        public void InitSeed(int seed)
        {
            randomizer = new Random(seed);
        }

        public float GenerateValue()
        {
            float randomFloatMinValue = (float)randomizer.NextDouble() * float.MinValue;
            float randomFLoatMaxValue = (float)randomizer.NextDouble() * float.MaxValue;

            return randomFloatMinValue + randomFLoatMaxValue;
        }

        public float GenerateValue(float min, float max)
        {
            if (min >= max)
            {
                throw new ArgumentException(Consts.MinMaxValueExceptionMsg);
            }

            return min + (float)randomizer.NextDouble() * (max - min);
        }

        public float GeneratePositiveValue()
        {
            return this.GenerateValue();
        }

        public float GenerateNegativeValue()
        {
            return -this.GenerateValue();
        }
    }
}
