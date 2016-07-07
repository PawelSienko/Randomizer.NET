using System.Globalization;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.DateTime
{
    public class DateTimeInRangeOutputTest : DateTimeOutputTest
    {
        public DateTimeInRangeOutputTest(IRandomDateTime randomDateTime, ILogger fileLogger)
            : base(randomDateTime, fileLogger)
        {
        }

        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min, max);

            // ReSharper disable once PossibleNullReferenceException
            System.DateTime minValue = (System.DateTime)min;
            // ReSharper disable once PossibleNullReferenceException
            System.DateTime maxValue = (System.DateTime)max;

            for (int i = 0; i < ExecutionTimes; i++)
            {
                System.DateTime randomValue = randomDateTime.GenerateValue(minValue, maxValue);

                // very specific condition :(
                if ((randomValue > maxValue || randomValue < minValue) && IsDifferenceonlyInMilliseconds(minValue, maxValue, randomValue) == false)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }

        private static bool IsDifferenceonlyInMilliseconds(System.DateTime minValue, System.DateTime maxValue, System.DateTime randomValue)
        {
            return IsSpecificCondition(minValue, randomValue) || IsSpecificCondition(maxValue, randomValue);
        }

        private static bool IsSpecificCondition(System.DateTime comparisonValue, System.DateTime randomValue)
        {
            if ((comparisonValue.Year == randomValue.Year && comparisonValue.Month == randomValue.Month
                 && comparisonValue.Day == randomValue.Day && comparisonValue.Hour == randomValue.Hour
                 && comparisonValue.Minute == randomValue.Minute && comparisonValue.Second == randomValue.Second))
            {
                return true;
            }

            return false;
        }
    }
}