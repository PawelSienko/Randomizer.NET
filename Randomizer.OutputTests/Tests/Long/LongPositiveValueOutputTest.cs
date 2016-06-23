using System.Globalization;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Long
{
    public class LongPositiveValueOutputTest : LongOutputTest
    {
        public LongPositiveValueOutputTest(IRandomLong randomLong, ILogger fileLogger)
            : base(randomLong, fileLogger)
        {
        }
        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min, max);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                long randomValue = randomLong.GeneratePositiveValue();
                if (randomValue < 0)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}