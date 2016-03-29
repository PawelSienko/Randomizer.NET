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
        public void FloatWithRangeShouldReturnValueWithinPassedRange()
        {
            // Arrange
            var someFloat = Some.Float(10, 20);

            // Assert
            Assert.IsTrue(someFloat >= 10);
            Assert.IsTrue(someFloat <= 20);
        }
    }
}
