using System;
using Randomizer.Interfaces;

namespace Randomizer.Types
{
    public class RandomFloatGenerator : IRandomFloat
    {
        private Random randomizer;

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

            int roundedMin = (int)Math.Round(min, MidpointRounding.AwayFromZero);
            int roundedMax = (int)Math.Round(max, MidpointRounding.AwayFromZero);

            float randomValue = randomizer.Next(roundedMin, roundedMax);
            float randomFraction = (float)randomizer.NextDouble();

            float randomValueWithFraction = randomValue + randomFraction;

            if (randomValueWithFraction < min)
            {
                return randomValueWithFraction + 0.5f;
            }
            else if (randomValueWithFraction > max)
            {
                return randomValueWithFraction - 0.5f;
            }

            return randomValueWithFraction;
        }

        public float GeneratePositiveValue(float min = float.MaxValue, float max = float.MaxValue)
        {
            return this.GenerateValue(min, max);
        }

        public float GenerateNegativeValue(float min = float.MinValue, float max = float.MaxValue)
        {
            return this.GenerateValue(min, max);
        }
    }
}
