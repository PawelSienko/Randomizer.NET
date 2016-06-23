using System.Globalization;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Decimal
{
    public class DecimalPositiveValueOutputTest : DecimalOutputTest
    {
        public DecimalPositiveValueOutputTest(IRandomDecimal randomDecimal, ILogger logger)
            : base(randomDecimal, logger)
        {
        }

        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min, max);
            for (int i = 0; i < ExecutionTimes; i++)
            {
                decimal randomValue = randomDecimal.GeneratePositiveValue();
                if (randomValue < 0)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}
