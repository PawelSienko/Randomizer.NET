using System;
using System.Linq;
using NUnit.Framework;

namespace Randomizer.UnitTests
{
    [TestFixture]
    public class SomeTests
    {
        [Test]
        public void StringShouldReturn10CharactersTextWhenLengthIs10()
        {
            // Act
            var text = Some.String(MaxRandom.Ten);

            // Assert
            Assert.AreEqual((int)MaxRandom.Ten, text.Length);
        }

        [Test]
        public void StringShouldReturn20CharactersTextWhenLengthIs20()
        {
            // Act
            var text = Some.String(MaxRandom.Twenty);

            // Assert
            Assert.AreEqual((int)MaxRandom.Twenty, text.Length);
        }

        [Test]
        public void StringShouldReturn100CharactersTextWhenLengthIs100()
        {
            // Act
            var text = Some.String(MaxRandom.Hundred);

            // Assert
            Assert.AreEqual((int)MaxRandom.Hundred, text.Length);
        }

        [Test]
        public void StringShouldReturnOnlyLettersWhenEnumIsCorrect()
        {
            // Act
            var charactersArray = Some.String(MaxRandom.Twenty).ToCharArray();

            // Assert
            var alphanumericArray = charactersArray.Where(Char.IsLetter).ToArray();
            Assert.AreEqual((int)MaxRandom.Twenty, alphanumericArray.Length);
        }

        [Test]
        public void StringUpperShouldReturnOnlyUppercaseWhenPassMaxRandomValue()
        {
            // Act 
            var upperLetters = Some.StringUpper(MaxRandom.Hundred);

            // Assert
            var filteredUppercaseCount = upperLetters.Where(Char.IsUpper).ToList().Count;
            Assert.AreEqual((int)MaxRandom.Hundred, filteredUppercaseCount);
        }

        [Test]
        public void StringLowerShouldReturnOnlyLowercaseWhenPassMaxRandom()
        {
            // Act 
            var lowerLetters = Some.StringLower(MaxRandom.Hundred);

            // Assert
            var filteredUppercaseCount = lowerLetters.Where(Char.IsLower).ToList().Count;
            Assert.AreEqual((int)MaxRandom.Hundred, filteredUppercaseCount);
        }

        [Test]
        public void DigitsAsStringShouldReturnDigitsOnly()
        {
            // Act 
            var digitsAsString = Some.DigitsAsString(MaxRandom.Hundred);

            // Assert
            var filtereddigitsCount = digitsAsString.Where(Char.IsDigit).ToList().Count;
            Assert.AreEqual((int)MaxRandom.Hundred, filtereddigitsCount);
        }

        [Test]
        public void FutureDateShouldReturnNewerDate()
        {
            // Arrange
            var dateTimeNow = DateTime.Now;

            // Arrange 
            var someFutureDate = Some.FutureDate();

            // Assert
            Assert.IsTrue(dateTimeNow < someFutureDate);
        }

        [Test]
        public void PastDateShouldReturnOlderDate()
        {
            // Act
            var dateTimeNow = DateTime.Now;

            // Arrange 
            var somePastDate = Some.PastDate();

            // Assert
            Assert.IsTrue(dateTimeNow > somePastDate);
        }

        [Test]
        public void FloatShouldThrowExceptionWhenMinIsGreatherThanMax()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => Some.Float(10, 5));
        }

        [Test]
        public void FloatShouldReturnValueWithinPassedRange()
        {
            float min = 100.01f;
            float max = 1892891.998781f;

            // Arrange
            var someFloat = Some.Float(min, max);

            // Assert
            Assert.IsTrue(someFloat >= min);
            Assert.IsTrue(someFloat <= max);
        }

        /// <summary>
        /// Float should return float value between max float range values.
        /// </summary>
        [Test]
        public void FloatShouldReturnValueWhenRangeIsVeryWide()
        {
            float min = float.MinValue;
            float max = float.MaxValue;

            // Arrange
            var someFloat = Some.Float(min, max);

            // Assert
            Assert.GreaterOrEqual(someFloat, min);
            Assert.LessOrEqual(someFloat, max);
        }

        [Test]
        public void NegativeFloatShouldReturnNegativeFloatValue()
        {
            // Arrange
            var negativeFloat = Some.NegativeFloat();

            // Assert
            Assert.LessOrEqual(negativeFloat, 0);
        }

        [Test]
        public void PositiveFloatShouldReturnPositiveFloatValue()
        {
            // Arrange
            var positiiveFloat = Some.PositiveFloat();

            // Assert
            Assert.GreaterOrEqual(positiiveFloat, 0);
        }

        [Test]
        public void DoubleShouldReturnProperValueWithinRange()
        {
            // Arrange 
            double min = 1.765d;
            double max = 100.091892d;

            // Act
            var someDouble = Some.Double(min, max);

            // Assert
            Assert.GreaterOrEqual(someDouble, min);
            Assert.LessOrEqual(someDouble, max);
        }
    }
}
