using System;
using System.Collections.Generic;
using System.Linq;

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
            if (values == null || values.Length <= 1)
            {
                throw new ArgumentException();
            }

            int numberOfItemsToRandom = values.Length;

            int randomIndex = randomizer.Next(0, numberOfItemsToRandom - 1);

            return values[randomIndex];
        }

        public virtual TType GenerateValueApartFrom(params TType[] excludedValues)
        {
            TType randomValue;
            do
            {
                randomValue = GetRandomValue();
            } while (excludedValues.All(item => EqualityComparer<TType>.Default.Equals(item, randomValue)));

            return randomValue;
        }
        protected abstract TType GetRandomValue();
    }
}
