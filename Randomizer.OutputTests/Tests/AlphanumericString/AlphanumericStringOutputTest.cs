using System;
using System.Collections.Generic;
using System.Linq;
using Common.Core.Validation;
using Randomizer.Interfaces.ReferenceTypes;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.AlphanumericString
{
    public class AlphanumericStringOutputTest : OutputTestBase
    {
        // ReSharper disable once InconsistentNaming
        protected IRandomAlphanumericString randomAlphanumericString;

        public AlphanumericStringOutputTest(IRandomAlphanumericString randomAlphanumericString, ILogger fileLogger)
        {
            Validator.ValidateNull(randomAlphanumericString);
            Validator.ValidateNull(fileLogger);
            this.randomAlphanumericString = randomAlphanumericString;
            FileLogger = fileLogger;
        }

        public override void PerformTest(object min = null, object max = null)
        {
            
        }

        protected bool IsLetterOrDigit(string randomValue)
        {
            char[] randomValueAsArray = randomValue.ToCharArray();
            return randomValueAsArray.All(Char.IsLetterOrDigit);
        }
    }
}
