using System.Globalization;
using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.OutputTests.Tests.AlphanumericString
{
    public class AlphanumericStringFixedLengthOutputTest : AlphanumericStringOutputTest
    {
        public AlphanumericStringFixedLengthOutputTest(IRandomAlphanumericString randomAlphanumericString, ILogger fileLogger)
            : base(randomAlphanumericString, fileLogger)
        {
        }

        public override void PerformTest(object min = null, object max = null)
        {
            for (int i = 0; i < ExecutionTimes; i++)
            {
                string randomValue = randomAlphanumericString.GenerateValue(100);
                if (string.IsNullOrEmpty(randomValue))
                {
                    wrongResults.Add("NULL");
                }
                else if (randomValue.Length != 100 || IsLetterOrDigit(randomValue) == false)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}
