using System;
using System.Text;

namespace Radlon.Common.RandomProvider
{
    /// <summary>
    /// Responsible for generating some random values.
    /// </summary>
    public static class Some
    {
        private const int FirstUpperInAscii = 'A';
        private const int LastUpperInAscii = 'Z';
        private const int LastLetterInAscii = 'z';
        private const int FirstLowerInAscii = 'a';
        private const int LastLowerInAscii = 'z';
        private const int FirstDigitInAscii = '0';
        private const int LastDigitInAscii = '9';

        private static readonly StringBuilder RandomCharacters;
        // ReSharper disable once InconsistentNaming
        private static readonly Random randomizer;

        /// <summary>
        /// Default constructor
        /// </summary>
        static Some()
        {
            RandomCharacters = new StringBuilder();
            randomizer = new Random();
        }

        /// <summary>Generates some random  string.</summary>
        /// <param name="maxRandom">Defines how many characters will be generated.</param>
        /// <returns>Random string.</returns>
        public static string String(MaxRandom maxRandom)
        {
            RandomCharacters.Clear();

            int numberOfLetters = (int)maxRandom;

            do
            {
                char character = RandomCharacter(FirstUpperInAscii, LastLetterInAscii);
                // ReSharper disable once RedundantBoolCompare
                if (char.IsLetter(character) == true)
                {
                    RandomCharacters.Append(character);
                }
            } while (RandomCharacters.Length < numberOfLetters);

            return RandomCharacters.ToString();
        }
        /// <summary>Generates some random  string contaoning only lower case.</summary>
        /// <param name="maxRandom">Defines how many characters will be generated.</param>
        /// <returns>Random string.</returns>
        public static string StringLower(MaxRandom maxRandom)
        {
            RandomCharacters.Clear();
            int numberOfLetters = (int)maxRandom;

            do
            {
                char character = RandomCharacter(FirstLowerInAscii, LastLowerInAscii);
                // ReSharper disable once RedundantBoolCompare
                if (char.IsLower(character) == true)
                {
                    RandomCharacters.Append(character);
                }
            } while (RandomCharacters.Length < numberOfLetters);

            return RandomCharacters.ToString();
        }

        /// <summary>Generates some random  string containing only upper case.</summary>
        /// <param name="maxRandom">Defines how many characters will be generated.</param>
        /// <returns>Random string.</returns>
        public static string StringUpper(MaxRandom maxRandom)
        {
            RandomCharacters.Clear();
            int numberOfLetters = (int)maxRandom;

            do
            {
                char character = RandomCharacter(FirstUpperInAscii, LastUpperInAscii);
                // ReSharper disable once RedundantBoolCompare
                if (char.IsUpper(character) == true)
                {
                    RandomCharacters.Append(character);
                }
            } while (RandomCharacters.Length < numberOfLetters);

            return RandomCharacters.ToString();
        }

        /// <summary>Generates some random digits as text.</summary>
        /// <param name="maxRandom">Defines how many characters will be generated.</param>
        /// <returns>Random digits.</returns>
        public static string DigitsAsString(MaxRandom maxRandom)
        {
            RandomCharacters.Clear();
            int numberOfLetters = (int)maxRandom;

            do
            {
                char character = RandomCharacter(FirstDigitInAscii, LastDigitInAscii);
                // ReSharper disable once RedundantBoolCompare
                if (char.IsDigit(character) == true)
                {
                    RandomCharacters.Append(character);
                }
            } while (RandomCharacters.Length < numberOfLetters);

            return RandomCharacters.ToString();
        }

        /// <summary>Generates some random date.</summary>
        /// <returns>Random date newer than date time now.</returns>
        public static DateTime FutureDate()
        {
            DateTime dateTImeNow = DateTime.Now;
            int randomValue = randomizer.Next(1, 1000);
            return dateTImeNow.AddDays(randomValue);
        }

        /// <summary>Generates some random date.</summary>
        /// <returns>Random date older than date time now.</returns>
        public static DateTime PastDate()
        {
            DateTime dateTimeNow = DateTime.Now;
            int randomValue = randomizer.Next(1, 1000);
            return dateTimeNow.AddDays(-randomValue);
        }

        /// <summary>
        /// Generates some random integer.
        /// </summary>
        /// <returns>Random integer.</returns>
        public static int Integer()
        {
            return randomizer.Next(int.MinValue, int.MaxValue);
        }

        /// <summary>Generates integer from range.</summary>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <returns></returns>
        public static int Integer(int min, int max)
        {
            return randomizer.Next(min, max);
        }

        /// <summary>
        /// Generates some random float.
        /// </summary>
        /// <returns>Random float.</returns>
        public static float Float()
        {
            int randomInt = randomizer.Next();
            float fraction = (float)randomizer.NextDouble();

            return randomInt + fraction;
        }

        /// <summary>Generates float from range.</summary>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <returns></returns>
        public static float Float(float min, float max)
        {
            if (min >= max)
            {
                throw new ArgumentException("Min value must be less than max.");
            }

            float roundedMin = (float)Math.Round(min + 0.5);
            float roundedMax = (float)Math.Round(max - 0.5);

            int randomInt = randomizer.Next((int)roundedMin, (int)roundedMax);
            float fraction = (float)randomizer.NextDouble();

            return randomInt + fraction;
        }

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
        /// </summary>
        /// <returns>Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.</returns>
        public static double Double()
        {
            return randomizer.NextDouble();
        }

        /// <summary>
        /// Returns random decimal value.
        /// </summary>
        /// <returns>Random decimal value.</returns>
        public static decimal Decimal()
        {
            decimal value = randomizer.Next();
            decimal divider = randomizer.Next();
            return value / divider;
        }

        /// <summary>
        /// Generates some random char.
        /// </summary>
        /// <param name="firstLetter">First char where it starts.</param>
        /// <param name="lastLetter">Last char where it starts.</param>
        /// <returns>Random char.</returns>
        private static char RandomCharacter(int firstLetter, int lastLetter)
        {
            int randomValue = randomizer.Next(firstLetter, lastLetter);
            char character = (char)randomValue;
            // ReSharper disable once RedundantBoolCompare
            return character;
        }
    }
}


