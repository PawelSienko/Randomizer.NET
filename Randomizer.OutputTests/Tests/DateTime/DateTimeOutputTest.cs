using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.DateTime
{
    public class DateTimeOutputTest : OutputTestBase
    {
        // ReSharper disable once InconsistentNaming
        protected IRandomDateTime randomDateTime;

        public DateTimeOutputTest(IRandomDateTime randomDateTime, ILogger fileLogger)
        {
            Validator.ValidateNull(randomDateTime);
            Validator.ValidateNull(fileLogger);
            this.randomDateTime = randomDateTime;
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
