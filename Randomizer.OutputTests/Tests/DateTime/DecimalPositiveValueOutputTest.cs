using System.Globalization;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Tests.DateTime;

namespace Randomizer.OutputTests.Tests.Decimal
{
    public class DateTimePositiveValueOutputTest : DateTimeOutputTest
    {
        public DateTimePositiveValueOutputTest(IRandomDateTime randomDateTime, ILogger logger)
            : base(randomDateTime, logger)
        {
        }

        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min, max);
            for (int i = 0; i < ExecutionTimes; i++)
            {
                System.DateTime randomValue = randomDateTime.GeneratePositiveValue();
                if (randomValue < System.DateTime.Now)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}
