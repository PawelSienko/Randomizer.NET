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
            float randomFloatMaxValue = (float)randomizer.NextDouble() * float.MaxValue;

            return randomFloatMinValue + randomFloatMaxValue;
        }

        public float GenerateValue(float min, float max)
        {
            if (min >= max)
            {
                throw new ArgumentException(Consts.MinMaxValueExceptionMsg);
            }
            if (IsConditionToReachLimit())
            {
                return float.MaxValue;
            }

            return min + (float)randomizer.NextDouble() * (max - min);
        }

        public float GeneratePositiveValue()
        {
            if (IsConditionToReachLimit())
            {
                return float.MaxValue;
            }

            return this.GenerateValue();
        }

        public float GenerateNegativeValue()
        {
            if (IsConditionToReachLimit())
            {
                return float.MinValue;
            }

            return -this.GenerateValue();
        }
    }
}
