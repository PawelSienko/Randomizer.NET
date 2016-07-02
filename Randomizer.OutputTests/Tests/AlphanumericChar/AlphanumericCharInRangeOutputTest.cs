using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.OutputTests.Tests.AlphanumericChar
{
    public class AlphanumericCharInRangeOutputTest : AlphanumericCharOutputTest
    {
        public AlphanumericCharInRangeOutputTest(IRandomCharacter randomCharacter, ILogger fileLogger)
            : base(randomCharacter, fileLogger)
        {
        }

        public override void PerformTest(object min = null, object max = null)
        {
            base.PerformTest(min, max);

            // ReSharper disable once PossibleNullReferenceException
            char minValue = (char)min;
            // ReSharper disable once PossibleNullReferenceException
            char maxValue = (char)max;

            int minValueIndex = Consts.AlphanumericCharacters.IndexOf(minValue);
            int maxValueIndex = Consts.AlphanumericCharacters.IndexOf(maxValue);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                char randomValue = randomCharacter.GenerateValue(minValue, maxValue);
                int indexOfRandomValue = Consts.AlphanumericCharacters.IndexOf(randomValue);
                
                if (indexOfRandomValue < minValueIndex || indexOfRandomValue > maxValueIndex)
                {
                    wrongResults.Add(Consts.AlphanumericCharacters[indexOfRandomValue].ToString());
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}