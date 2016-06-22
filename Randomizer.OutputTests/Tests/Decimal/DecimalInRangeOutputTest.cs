using System.Globalization;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Decimal
{
    public class DecimalInRangeOutputTest : DecimalOutputTest
    {
        public DecimalInRangeOutputTest(IRandomDecimal randomDecimal, ILogger fileLogger)
            : base(randomDecimal, fileLogger)
        {
        }

        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min, max);

            // ReSharper disable once PossibleNullReferenceException
            decimal minValue = (decimal)min;
            // ReSharper disable once PossibleNullReferenceException
            decimal maxValue = (decimal)max;

            for (int i = 0; i < ExecutionTimes; i++)
            {
                var randomValue = randomDecimal.GenerateValue(minValue, maxValue);
                if (randomValue > maxValue || randomValue < minValue)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}