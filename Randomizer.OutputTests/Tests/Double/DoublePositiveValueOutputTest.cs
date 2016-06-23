using System.Globalization;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Double
{
    public class DoublePositiveValueOutputTest : DoubleOutputTest
    {
        public DoublePositiveValueOutputTest(IRandomDouble randomDouble, ILogger logger)
            : base(randomDouble, logger)
        {
        }

        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min, max);
            for (int i = 0; i < ExecutionTimes; i++)
            {
                double randomValue = randomDouble.GeneratePositiveValue();
                if (randomValue < 0)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}
