using System.Collections.Generic;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.OutputTests.Tests
{
    public class FloatInRangeOutputTest : OutputTestBase
    {
        private IRandomFloat randomFloat;
        private int executionNumber;

        public FloatInRangeOutputTest(IRandomFloat randomFloat, ILogger fileLogger, int executionNumber)
        {
            Validator.ValidateNull(randomFloat);
            Validator.ValidateNull(fileLogger);
            this.randomFloat = randomFloat;
            base.FileLogger = fileLogger;
            this.executionNumber = executionNumber;
        }

        public override void PerformTest(object min, object max)
        {
            Validator.ValidateNull(min);
            Validator.ValidateNull(max);

            float randomValue;
            float minValue = (float)min;
            float maxValue = (float)max;
            List<string> wrongResults = new List<string>();

            for (int i = 0; i < executionNumber; i++)
            {
                randomValue = randomFloat.GenerateValue(minValue, maxValue);
                if (randomValue > maxValue|| randomValue < minValue)
                {
                    wrongResults.Add(randomValue.ToString());
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}