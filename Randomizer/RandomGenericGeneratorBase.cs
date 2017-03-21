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

        public virtual TType GenerateValue(params TType[] values)
        {
            Validator.ValidateNull(values);
            Validator.ValidateCondition(values, item => values.Length > 0);
            Validator.ValidateCondition(values, item => values.Length > 1);

            int numberOfItemsToRandom = values.Length;

            int randomIndex = randomizer.Next(0, numberOfItemsToRandom - 1);

            return values[randomIndex];
        }
    }
}
