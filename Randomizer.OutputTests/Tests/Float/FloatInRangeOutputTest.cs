using System.Globalization;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Float
{
    public class FloatInRangeOutputTest : FloatOutputTest
    {
        public FloatInRangeOutputTest(IRandomFloat randomFloat, ILogger fileLogger)
            : base(randomFloat, fileLogger)
        {
        }

        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min, max);

            float minValue = (float)min;
            float maxValue = (float)max;

            for (int i = 0; i < ExecutionTimes; i++)
            {
                float randomValue = randomFloat.GenerateValue(minValue, maxValue);
                if (randomValue > maxValue || randomValue < minValue)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}