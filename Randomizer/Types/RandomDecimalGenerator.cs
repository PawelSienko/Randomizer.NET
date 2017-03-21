using System;
using System.Linq;
using Randomizer.Interfaces.ValueTypes;

// ReSharper disable once CheckNamespace
namespace Randomizer
{
    public class RandomDecimalGenerator : RandomGenericGeneratorBase<decimal>, IRandomDecimal
    {
        public RandomDecimalGenerator()
        {

        }
        public RandomDecimalGenerator(int seed)
            : base(seed)
        {

        }

        public decimal GenerateValue()
        {
            return GetRandomValue();
        }

        public decimal GenerateValue(decimal min, decimal max)
        {
            if (min >= max)
            {
                throw new ArgumentException(Consts.MinMaxValueExceptionMsg);
            }

            if (IsConditionToReachLimit())
            {
                return max;
            }
            decimal randomDecimal = (decimal)randomizer.NextDouble();
            return min + randomDecimal * max - randomDecimal * min;
        }
        
        public decimal GeneratePositiveValue()
        {
            if (IsConditionToReachLimit())
            {
                return decimal.MaxValue;
            }

            return (decimal)randomizer.NextDouble() * decimal.MaxValue;
        }

        public decimal GenerateNegativeValue()
        {
            if (IsConditionToReachLimit())
            {
                return decimal.MinValue;
            }

            return (decimal)randomizer.NextDouble() * decimal.MinValue;
        }

        protected  override decimal GetRandomValue()
        {
            decimal randomPositive = (decimal)randomizer.NextDouble() * decimal.MaxValue;
            decimal randomNegative = (decimal)randomizer.NextDouble() * decimal.MinValue;
            if (IsConditionToReachLimit())
            {
                return decimal.MaxValue;
            }

            return randomNegative + randomPositive;
        }
    }
}