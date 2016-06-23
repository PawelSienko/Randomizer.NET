using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Short
{
    public class ShortOutputTest : OutputTestBase
    {
        // ReSharper disable once InconsistentNaming
        protected IRandomShort randomShort;

        public ShortOutputTest(IRandomShort randomShort, ILogger fileLogger)
        {
            Validator.ValidateNull(randomShort);
            Validator.ValidateNull(fileLogger);
            this.randomShort = randomShort;
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