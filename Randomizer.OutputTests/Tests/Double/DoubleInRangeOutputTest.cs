using System.Globalization;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Double
{
    public class DoubleInRangeOutputTest : DoubleOutputTest
    {
        public DoubleInRangeOutputTest(IRandomDouble randomDecimal, ILogger fileLogger)
            : base(randomDecimal, fileLogger)
        {
        }

        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min, max);

            // ReSharper disable once PossibleNullReferenceException
            double minValue = (double)min;
            // ReSharper disable once PossibleNullReferenceException
            double maxValue = (double)max;

            for (int i = 0; i < ExecutionTimes; i++)
            {
                double randomValue = randomDouble.GenerateValue(minValue, maxValue);
                if (randomValue > maxValue || randomValue < minValue)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}