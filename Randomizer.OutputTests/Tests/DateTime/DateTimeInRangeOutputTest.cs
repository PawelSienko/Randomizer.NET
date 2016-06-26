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
                if (randomValue > maxValue || randomValue < minValue)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}