using System;
using System.Linq;
using NUnit.Framework;
using Radlon.Common.RandomProvider;

namespace Radlon.Common.UnitTests
{
    [TestFixture]
    public class SomeTests
    {
        [Test]
        public void StringShouldReturnTextWhenLengthIsTen()
        {
            // Act
            var text = Some.String(MaxRandom.Ten);

            // Assert
            Assert.AreEqual((int)MaxRandom.Ten, text.Length);
        }

        [Test]
        public void StringShouldReturnTextWhenLengthIsTwenty()
        {
            // Act
            var text = Some.String(MaxRandom.Twenty);

            // Assert
            Assert.AreEqual((int)MaxRandom.Twenty, text.Length);
        }

        [Test]
        public void StringShouldReturnTextWhenLengthIsHundred()
        {
            // Act
            var text = Some.String(MaxRandom.Hundred);

            // Assert
            Assert.AreEqual((int)MaxRandom.Hundred, text.Length);
        }

        [Test]
        public void StringShouldReturnOnlyLetterWhenEnumIsCorrect()
        {
            // Act
            var charactersArray = Some.String(MaxRandom.Twenty).ToCharArray();

            // Assert
            var alphanumericArray = charactersArray.Where(Char.IsLetter).ToArray();
            Assert.AreEqual((int)MaxRandom.Twenty, alphanumericArray.Length);
        }

        [Test]
        public void StringUpperShouldReturnOnlyUpperCaseWhenPassMaxRandom()
        {
            // Act 
            var upperLetters = Some.StringUpper(MaxRandom.Hundred);

            // Assert
            var filteredUppercaseCount = upperLetters.Where(Char.IsUpper).ToList().Count;
            Assert.AreEqual((int)MaxRandom.Hundred, filteredUppercaseCount);
        }

        [Test]
        public void StringLowerhouldReturnOnlyLowerWhenPassMaxRandom()
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
        public void PastDateShouldReturnSomeOlderDates()
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
        public void NegativeFloatShouldReturnSomeNegativeFloatValue()
        {
            // Arrange
            var negativeFloat = Some.NegativeFloat();

            // Assert
            Assert.LessOrEqual(negativeFloat, 0);
        }
    }
}
