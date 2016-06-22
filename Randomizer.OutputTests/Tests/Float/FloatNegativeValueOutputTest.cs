﻿using System.Globalization;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Float
{
    public class FloatNegativeValueOutputTest : FloatOutputTest
    {
        public FloatNegativeValueOutputTest(IRandomFloat randomFloat, ILogger logger)
            : base(randomFloat, logger)
        {
        }

        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min,max);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                var randomValue = randomFloat.GenerateNegativeValue();
                if (randomValue > 0)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}