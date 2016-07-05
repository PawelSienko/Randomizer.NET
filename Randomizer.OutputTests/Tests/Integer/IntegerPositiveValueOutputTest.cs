using System.Globalization;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Integer
{
    public class IntegerPositiveValueOutputTest : IntegerOutputTest
    {
        public IntegerPositiveValueOutputTest(IRandomInteger randomInteger, ILogger fileLogger)
            : base(randomInteger, fileLogger)
        {
        }
        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min, max);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                int randomValue = randomInteger.GeneratePositiveValue();
                if (randomValue < 0)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}