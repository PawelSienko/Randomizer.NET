using System.Globalization;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.DateTime
{
    public class DateTimeNegativeValueOutputTest : DateTimeOutputTest
    {
        public DateTimeNegativeValueOutputTest(IRandomDateTime randomDateTime, ILogger logger)
            : base(randomDateTime, logger)
        {
        }

        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min,max);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                System.DateTime randomValue = randomDateTime.GenerateNegativeValue();
                if (randomValue > System.DateTime.Now)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}