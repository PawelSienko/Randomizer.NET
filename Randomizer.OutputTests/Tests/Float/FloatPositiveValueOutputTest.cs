using System.Globalization;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests.Float
{
    public class FloatPositiveValueOutputTest : FloatOutputTest
    {
        public FloatPositiveValueOutputTest(IRandomFloat randomFloat, ILogger logger)
            : base(randomFloat,logger)
        {
        }

        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min,max);
            for (int i = 0; i < ExecutionTimes; i++)
            {
                float randomValue = randomFloat.GeneratePositiveValue();
                if (randomValue < 0)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}
