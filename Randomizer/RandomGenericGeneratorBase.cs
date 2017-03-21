using System.Collections.Generic;
using System.Linq;
using Common.Core.Validation;

namespace Randomizer
{
    public abstract class RandomGenericGeneratorBase<TType> : RandomGeneratorBase

    {
        protected RandomGenericGeneratorBase()
        { }

        protected RandomGenericGeneratorBase(int seed)
            : base(seed)

        { }

        public virtual TType GenerateValueWithin(params TType[] values)
        {
            Validator.ValidateNull(values);
            Validator.ValidateCondition(values, item => values.Length > 0);
            Validator.ValidateCondition(values, item => values.Length > 1);

            int numberOfItemsToRandom = values.Length;

            int randomIndex = randomizer.Next(0, numberOfItemsToRandom - 1);

            return values[randomIndex];
        }

        protected abstract TType GetRandomValue();

        public virtual TType GenerateValueApartFrom(params TType[] excludedValues)
        {
            TType randomValue;
            do
            {
                randomValue = GetRandomValue();
            } while (excludedValues.All(item => EqualityComparer<TType>.Default.Equals(item, randomValue)));

            return randomValue;
        }
    }
}
