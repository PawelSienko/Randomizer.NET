using System.Globalization;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Short
{
    public class ShortInRangeOutputTest : ShortOutputTest
    {
        public ShortInRangeOutputTest(IRandomShort randomShort, ILogger fileLogger)
            : base(randomShort, fileLogger)
        {
        }
        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min,max);

            // ReSharper disable once PossibleNullReferenceException
            short minValue = (short)min;
            // ReSharper disable once PossibleNullReferenceException
            short maxValue = (short)max;

            for (int i = 0; i < ExecutionTimes; i++)
            {
                short randomValue = randomShort.GenerateValue(minValue, maxValue);
                if (randomValue > maxValue || randomValue < minValue)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}