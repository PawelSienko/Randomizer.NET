using Common.Core.Validation;
using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.OutputTests.Tests.AlphanumericChar
{
    public class AlphanumericCharOutputTest : OutputTestBase
    {
        // ReSharper disable once InconsistentNaming
        protected IRandomCharacter randomCharacter;

        public AlphanumericCharOutputTest(IRandomCharacter randomCharacter, ILogger fileLogger)
        {
            Validator.ValidateNull(randomCharacter);
            Validator.ValidateNull(fileLogger);
            this.randomCharacter = randomCharacter;
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
