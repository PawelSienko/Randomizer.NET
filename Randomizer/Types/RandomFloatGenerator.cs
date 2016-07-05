using System;
using Randomizer.Interfaces.ValueTypes;

// ReSharper disable once CheckNamespace
namespace Randomizer
{
    public sealed class RandomFloatGenerator : RandomGeneratorBase, IRandomFloat
    {
        public RandomFloatGenerator()
        { }

        public RandomFloatGenerator(int seed)
            : base(seed)
        {
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
            float randomFloat = (float)randomizer.NextDouble();
            return min + randomFloat * max - randomFloat * min;
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
