using System;
using Randomizer.Interfaces;

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
            int expander = randomizer.Next(0, 38);
            int randomValue = randomizer.Next(0, 3);
            float randomFraction = (float)randomizer.Next(0, 4) / 10;
            float randomFloatValue = randomValue + randomFraction;
            return randomFloatValue * randomFloatValue * (float)Math.Pow(10, expander);
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
            return this.GenerateValue();
        }
    }
}
