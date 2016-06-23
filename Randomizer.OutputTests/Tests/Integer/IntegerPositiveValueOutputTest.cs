using System.Globalization;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Integer
{
    public class IntegerPositiveValueOutputTest : IntegerOutputTest
    {
        public IntegerPositiveValueOutputTest(IRandomInteger randomLong, ILogger fileLogger)
            : base(randomLong, fileLogger)
        {
        }
        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min, max);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                int randomValue = randomLong.GeneratePositiveValue();
                if (randomValue < 0)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}