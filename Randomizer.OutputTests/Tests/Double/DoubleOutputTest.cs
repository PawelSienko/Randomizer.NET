using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Double
{
    public class DoubleOutputTest : OutputTestBase
    {
        // ReSharper disable once InconsistentNaming
        protected IRandomDouble randomDouble;

        public DoubleOutputTest(IRandomDouble randomDouble, ILogger fileLogger)
        {
            Validator.ValidateNull(randomDouble);
            Validator.ValidateNull(fileLogger);
            this.randomDouble = randomDouble;
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
