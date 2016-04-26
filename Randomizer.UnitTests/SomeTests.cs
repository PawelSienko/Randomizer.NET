using System;
using System.Linq;
using NUnit.Framework;

namespace Randomizer.UnitTests
{
    [TestFixture]
    public class SomeTests
    {
        [Test]
        [Obsolete]
        public void StringShouldReturn10CharactersTextWhenLengthIs10()
        {
            // Act
            var text = Some.String(MaxRandom.Ten);

            // Assert
            Assert.AreEqual((int)MaxRandom.Ten, text.Length);
        }

        [Test]
        [Obsolete]
        public void StringShouldReturn20CharactersTextWhenLengthIs20()
        {
            // Act
            var text = Some.String(MaxRandom.Twenty);

            // Assert
            Assert.AreEqual((int)MaxRandom.Twenty, text.Length);
        }

        [Test]
        [Obsolete]
        public void StringShouldReturn100CharactersTextWhenLengthIs100()
        {
            // Act
            var text = Some.String(MaxRandom.Hundred);

            // Assert
            Assert.AreEqual((int)MaxRandom.Hundred, text.Length);
        }

        [Test]
        [Obsolete]
        public void StringShouldReturnOnlyLettersWhenEnumIsCorrect()
        {
            // Act
            var charactersArray = Some.String(MaxRandom.Twenty).ToCharArray();

            // Assert
            var alphanumericArray = charactersArray.Where(Char.IsLetter).ToArray();
            Assert.AreEqual((int)MaxRandom.Twenty, alphanumericArray.Length);
        }

        [Test]
        [Obsolete]
        public void StringUpperShouldReturnOnlyUppercaseWhenPassMaxRandomValue()
        {
            // Act 
            var upperLetters = Some.StringUpper(MaxRandom.Hundred);

            // Assert
            var filteredUppercaseCount = upperLetters.Where(Char.IsUpper).ToList().Count;
            Assert.AreEqual((int)MaxRandom.Hundred, filteredUppercaseCount);
        }

        [Test]
        [Obsolete]
        public void StringLowerShouldReturnOnlyLowercaseWhenPassMaxRandom()
        {
            // Act 
            var lowerLetters = Some.StringLower(MaxRandom.Hundred);

            // Assert
            var filteredUppercaseCount = lowerLetters.Where(Char.IsLower).ToList().Count;
            Assert.AreEqual((int)MaxRandom.Hundred, filteredUppercaseCount);
        }

        [Test]
        public void StringLowerShouldReturnOnlyLowercaseWhenPassLengthValue()
        {
            // Arrange
            int length = 1000;

            // Act 
            var lowerLetters = Some.StringLower(length);

            // Assert
            var filteredUppercaseCount = lowerLetters.Where(Char.IsLower).ToList().Count;
            Assert.AreEqual(length, filteredUppercaseCount);
        }


        [Test]
        public void StringLowerShouldThrowExceptionWhenLengthIsBelowZero()
        {
            // Arrange
            int length = -1;

            // Act 
            Assert.Throws<ArgumentException>(() => Some.StringLower(length));
        }


        [Test]
        public void StringLowerShouldThrowExceptionWhenLengthIsZero()
        {
            // Arrange
            int length = 0;

            // Act 
            Assert.Throws<ArgumentException>(() => Some.StringLower(length));
        }

        [Test]
        public void StringUpperShouldThrowExceptionWhenLengthIsZero()
        {
            // Arrange
            int length = 0;

            // Act 
            Assert.Throws<ArgumentException>(() => Some.StringUpper(length));
        }

        [Test]
        public void StringUpperShouldThrowExceptionWhenLengthIsBelowZero()
        {
            // Arrange
            int length = -1;

            // Act 
            Assert.Throws<ArgumentException>(() => Some.StringUpper(length));
        }

        [Test]
        public void StringUpperShouldReturnTextWithUppercasesWhenLenthValueIsPositive()
        {
            // Arrange
            int length = 1000;

            // Act 
            string text = Some.StringUpper(length);

            // Assert
            Assert.IsNotNull(text);
            Assert.IsNotEmpty(text);
            Assert.AreEqual(length, text.Length);
        }

        [Test]
        public void DigitsAsStringShouldReturnDigitsOnlyWhenLengthIsPassed()
        {
            // Arrange
            int length = 1000;

            // Act 
            var digitsAsString = Some.DigitsAsString(length);

            // Assert
            Assert.IsNotNull(digitsAsString);
            Assert.IsNotEmpty(digitsAsString);
            var filtereddigitsCount = digitsAsString.Where(Char.IsDigit).ToList().Count;
            Assert.AreEqual(length, filtereddigitsCount);
        }

        [Test]
        public void DigitsAsStringShouldThrowExceptionWhenLenghtIsBelowZero()
        {
            // Arrange
            int length = -1;

            // Act 
            Assert.Throws<ArgumentException>(() => Some.DigitsAsString(length));
        }



        [Test]
        public void DigitsAsStringShouldThrowExceptionWhenLenghtIsEqualZero()
        {
            // Arrange
            int length = 0;

            // Act 
            Assert.Throws<ArgumentException>(() => Some.DigitsAsString(length));
        }

        [Test]
        [Obsolete]
        public void DigitsAsStringShouldReturnDigitsOnly()
        {
            // Act 
            var digitsAsString = Some.DigitsAsString(MaxRandom.Hundred);

            // Assert
            var filtereddigitsCount = digitsAsString.Where(Char.IsDigit).ToList().Count;
            Assert.AreEqual((int)MaxRandom.Hundred, filtereddigitsCount);
        }

        [Test]
        public void StringWithLengthEqualsToZero()
        {
            // Arrange
            int length = 0;

            // Act
            Assert.Throws<ArgumentException>(() => Some.String(length));
        }

        [Test]
        public void StringWithLenthLessThanZero()
        {
            // Arrange
            int length = -1;

            // Act
            Assert.Throws<ArgumentException>(() => Some.String(length));
        }

        [Test]
        public void StringWithLengthGreaterThanZero()
        {
            // Arrange
            int length = 100;

            // Act
            string text = Some.String(length);

            // Assert
            Assert.IsNotNull(text);
            Assert.IsNotEmpty(text);
            Assert.AreEqual(length, text.Length);
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
        public void DateShouldReturnDateWithinRange()
        {
            // Act
            var since = DateTime.Now;
            var to = DateTime.Now.AddDays(100);

            // Arrange 
            var randomDate = Some.Date(since, to);

            // Assert
            Assert.GreaterOrEqual(randomDate, since);
            Assert.LessOrEqual(randomDate, to);
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
