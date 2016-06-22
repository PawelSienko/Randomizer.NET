using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Integer
{
    public class IntegerOutputTest : OutputTestBase
    {
        protected IRandomInteger randomInteger;

        public IntegerOutputTest(IRandomInteger randomInteger, ILogger fileLogger)
        {
            Validator.ValidateNull(randomInteger);
            Validator.ValidateNull(fileLogger);
            this.randomInteger = randomInteger;
            FileLogger = fileLogger;
        }

        public override void PerformTest(object min = null, object max = null)
        {
            ValidateConfitions();

            Validator.ValidateNull(min);
            Validator.ValidateNull(max);
        }
    }
}