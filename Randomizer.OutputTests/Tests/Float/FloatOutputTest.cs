using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Float
{
    public class FloatOutputTest : OutputTestBase
    {
        protected IRandomFloat randomFloat;
        public FloatOutputTest(IRandomFloat randomFloat, ILogger fileLogger)
        {
            Validator.ValidateNull(randomFloat);
            Validator.ValidateNull(fileLogger);
            this.randomFloat = randomFloat;
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
