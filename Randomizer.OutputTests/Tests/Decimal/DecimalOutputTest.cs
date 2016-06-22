using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Decimal
{
    public class DecimalOutputTest : OutputTestBase
    {
        // ReSharper disable once InconsistentNaming
        protected IRandomDecimal randomDecimal;

        public DecimalOutputTest(IRandomDecimal randomDecimal, ILogger fileLogger)
        {
            Validator.ValidateNull(randomDecimal);
            Validator.ValidateNull(fileLogger);
            this.randomDecimal = randomDecimal;
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
