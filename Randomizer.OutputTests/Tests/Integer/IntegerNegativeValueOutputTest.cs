﻿using System.Globalization;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Integer
{
    public class IntegerNegativeValueOutputTest : IntegerOutputTest
    {
        public IntegerNegativeValueOutputTest(IRandomInteger randomLong, ILogger fileLogger)
            : base(randomLong, fileLogger)
        {
        }
        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min, max);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                float randomValue = randomLong.GenerateNegativeValue();
                if (randomValue > 0)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}