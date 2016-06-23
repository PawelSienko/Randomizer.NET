using System.Globalization;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Short
{
    public class ShortNegativeValueOutputTest : ShortOutputTest
    {
        public ShortNegativeValueOutputTest(IRandomShort randomShort, ILogger fileLogger)
            : base(randomShort, fileLogger)
        {
        }
        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min, max);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                short randomValue = randomShort.GenerateNegativeValue();
                if (randomValue > 0)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}