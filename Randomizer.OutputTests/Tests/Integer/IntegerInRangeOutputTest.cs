﻿using System.Globalization;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Integer
{
    public class IntegerInRangeOutputTest : IntegerOutputTest
    {
        public IntegerInRangeOutputTest(IRandomInteger randomLong, ILogger fileLogger)
            : base(randomLong, fileLogger)
        {
        }
        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min,max);

            // ReSharper disable once PossibleNullReferenceException
            int minValue = (int)min;
            // ReSharper disable once PossibleNullReferenceException
            int maxValue = (int)max;

            for (int i = 0; i < ExecutionTimes; i++)
            {
                int randomValue = randomLong.GenerateValue(minValue, maxValue);
                if (randomValue > maxValue || randomValue < minValue)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}