﻿using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Integer
{
    public class IntegerOutputTest : OutputTestBase
    {
        protected IRandomInteger randomLong;

        public IntegerOutputTest(IRandomInteger randomLong, ILogger fileLogger)
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