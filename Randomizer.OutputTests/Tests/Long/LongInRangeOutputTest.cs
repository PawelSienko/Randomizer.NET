using System.Globalization;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Long
{
    public class LongInRangeOutputTest : LongOutputTest
    {
        public LongInRangeOutputTest(IRandomLong randomLong, ILogger fileLogger)
            : base(randomLong, fileLogger)
        {
        }
        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min,max);

            // ReSharper disable once PossibleNullReferenceException
            long minValue = (long)min;
            // ReSharper disable once PossibleNullReferenceException
            long maxValue = (long)max;

            for (int i = 0; i < ExecutionTimes; i++)
            {
                long randomValue = randomLong.GenerateValue(minValue, maxValue);
                if (randomValue > maxValue || randomValue < minValue)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}