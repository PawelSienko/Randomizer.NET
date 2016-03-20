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
            // Arrange
            var text = Some.String(MaxRandom.Ten);

            // Assert
            Assert.AreEqual((int)MaxRandom.Ten, text.Length);
        }

        [Test]
        public void StringShouldReturnTextWhenLengthIsTwenty()
        {
            // Arrange
            var text = Some.String(MaxRandom.Twenty);

            // Assert
            Assert.AreEqual((int)MaxRandom.Twenty, text.Length);
        }

        [Test]
        public void StringShouldReturnTextWhenLengthIsHundred()
        {
            // Arrange
            var text = Some.String(MaxRandom.Hundred);

            // Assert
            Assert.AreEqual((int)MaxRandom.Hundred, text.Length);
        }

        [Test]
        public void StringShouldReturnOnlyLetterWhenEnumIsCorrect()
        {
            // Arrange
            var charactersArray = Some.String(MaxRandom.Twenty).ToCharArray();

            // Assert
            var alphanumericArray = charactersArray.Where(Char.IsLetter).ToArray();
            Assert.AreEqual((int)MaxRandom.Twenty, alphanumericArray.Length);
        }

        [Test]
        public void StringUpperShouldReturnOnlyUpperCaseWhenPassMaxRandom()
        {
            // Arrange 
            var upperLetters = Some.StringUpper(MaxRandom.Hundred);

            // Assert
            var filteredUppercaseCount = upperLetters.Where(Char.IsUpper).ToList().Count;
            Assert.AreEqual((int)MaxRandom.Hundred, filteredUppercaseCount);
        }

        [Test]
        public void StringLowerhouldReturnOnlyLowerWhenPassMaxRandom()
        {
            // Arrange 
            var lowerLetters = Some.StringLower(MaxRandom.Hundred);

            // Assert
            var filteredUppercaseCount = lowerLetters.Where(Char.IsLower).ToList().Count;
            Assert.AreEqual((int)MaxRandom.Hundred, filteredUppercaseCount);
        }

        [Test]
        public void DigitsAsStringShouldReturnDigitsOnly()
        {
            // Arrange 
            var digitsAsString = Some.DigitsAsString(MaxRandom.Hundred);

            // Assert
            var filtereddigitsCount = digitsAsString.Where(Char.IsDigit).ToList().Count;
            Assert.AreEqual((int)MaxRandom.Hundred, filtereddigitsCount);
        }

        [Test]
        public void FutureDateShouldReturnNewerDate()
        {
            // Arrange 
            var someFutureDate = Some.FutureDate();
            var dateTimeNow = DateTime.Now;

            // Assert
            Assert.IsTrue(dateTimeNow < someFutureDate);
        }

        [Test]
        public void PastDateShouldReturnSomeOlderDates()
        {
            // Arrange 
            var somePastDate = Some.PastDate();
            var dateTimeNow = DateTime.Now;

            // Assert
            Assert.IsTrue(dateTimeNow > somePastDate);
        }
    }
}
