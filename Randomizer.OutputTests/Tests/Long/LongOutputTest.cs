using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Long
{
    public class LongOutputTest : OutputTestBase
    {
        // ReSharper disable once InconsistentNaming
        protected IRandomLong randomLong;

        public LongOutputTest(IRandomLong randomLong, ILogger fileLogger)
        {
            Validator.ValidateNull(randomLong);
            Validator.ValidateNull(fileLogger);
            this.randomLong = randomLong;
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