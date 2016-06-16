using System;
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
            float randomPositive = (float)randomizer.NextDouble() * float.MinValue;
            float randomNegative = (float)randomizer.NextDouble() * float.MaxValue;

            return randomPositive + randomNegative;
        }

        public float GenerateValue(float min, float max)
        {
            if (min >= max)
            {
                throw new ArgumentException(Consts.MinMaxValueExceptionMsg);
            }
            if (IsConditionToReachLimit())
            {
                return max;
            }

            return min + (float)randomizer.NextDouble() * (max - min);
        }

        public float GeneratePositiveValue()
        {
            if (IsConditionToReachLimit())
            {
                return float.MaxValue;
            }

            return (float)randomizer.NextDouble() * float.MaxValue;
        }

        public float GenerateNegativeValue()
        {
            if (IsConditionToReachLimit())
            {
                return float.MinValue;
            }

            return (float)randomizer.NextDouble() * float.MinValue;
        }
    }
}
