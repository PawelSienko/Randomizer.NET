using System;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Randomizer
{
    /// <summary>
    /// Responsible for generating some random values.
    /// </summary>
    public static class Some
    {
        private const string MinMaxValueExceptionMsg = "Min value must be less than max.";
        private const char FirstUpperInAscii = 'A';
        private const char LastUpperInAscii = 'Z';
        private const char FirstLowerInAscii = 'a';
        private const char LastLowerInAscii = 'z';
        private const char FirstDigitInAscii = '0';
        private const char LastDigitInAscii = '9';

        private static readonly StringBuilder RandomCharacters;
        // ReSharper disable once InconsistentNaming
        private static Random randomizer;

        /// <summary>
        /// Default constructor
        /// </summary>
        static Some()
        {
            RandomCharacters = new StringBuilder();
            randomizer = new Random((int)DateTime.Now.Ticks);
        }

        // ReSharper disable once InconsistentNaming
        [Obsolete]
        private static int seed;

        [Obsolete]
        public static int Seed
        {
            get { return seed; }
            set
            {
                seed = value;
                randomizer = new Random(seed);
            }
        }

        /// <summary>Generates some random  string.</summary>
        /// <param name="maxRandom">Defines how many characters will be generated.</param>
        /// <returns>Random string.</returns>
        [Obsolete("This method will be removed in the future. Please use another one with length parameter.")]
        public static string String(MaxRandom maxRandom)
        {
            RandomCharacters.Clear();

            int numberOfLetters = (int)maxRandom;

            do
            {
                char character = RandomCharacter(FirstUpperInAscii, LastLowerInAscii);
                // ReSharper disable once RedundantBoolCompare
                if (char.IsLetter(character) == true)
                {
                    RandomCharacters.Append(character);
                }
            } while (RandomCharacters.Length < numberOfLetters);

            return RandomCharacters.ToString();
        }

        /// <summary>Generates some random  string.</summary>
        /// <param name="length">Defines how many characters will be generated.</param>
        /// <returns>Random string.</returns>
        public static string String(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Lenght cannot be less or equal 0");
            }

            RandomCharacters.Clear();

            int numberOfLetters = length;

            do
            {
                char character = RandomCharacter(FirstUpperInAscii, LastLowerInAscii);
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
        [Obsolete("This method will be removed in the future. Please use another one with length parameter.")]
        public static string StringLower(MaxRandom maxRandom)
        {
            RandomCharacters.Clear();
            int numberOfLetters = (int)maxRandom;

            do
            {
                char character = RandomCharacter(FirstLowerInAscii, LastLowerInAscii);
                RandomCharacters.Append(character);
            } while (RandomCharacters.Length < numberOfLetters);

            return RandomCharacters.ToString();
        }

        /// <summary>
        /// Generates some random  string contaoning only lower case.
        /// </summary>
        /// <param name="length">>Defines how many characters will be generated.</param>
        /// <returns>Text containing only lowercases.</returns>
        public static string StringLower(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Lenght cannot be less or equal 0");
            }

            RandomCharacters.Clear();

            do
            {
                char character = RandomCharacter(FirstLowerInAscii, LastLowerInAscii);
                RandomCharacters.Append(character);
            } while (RandomCharacters.Length < length);

            return RandomCharacters.ToString();
        }

        /// <summary>
        /// Generates some random  string containing only upper case.
        /// </summary>
        /// <param name="length">Defines how many characters will be generated.</param>
        /// <returns>Text with uppercases.</returns>
        public static string StringUpper(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Lenght cannot be less or equal 0");
            }

            RandomCharacters.Clear();
            
            do
            {
                char character = RandomCharacter(FirstUpperInAscii, LastUpperInAscii);
                RandomCharacters.Append(character);
            } while (RandomCharacters.Length < length);

            return RandomCharacters.ToString();
        }

        /// <summary>Generates some random  string containing only upper case.</summary>
        /// <param name="maxRandom">Defines how many characters will be generated.</param>
        /// <returns>Random string.</returns>
        [Obsolete("This method will be removed in the future. Please use another one with length parameter.")]
        public static string StringUpper(MaxRandom maxRandom)
        {
            RandomCharacters.Clear();
            int numberOfLetters = (int)maxRandom;

            do
            {
                char character = RandomCharacter(FirstUpperInAscii, LastUpperInAscii);
                RandomCharacters.Append(character);
            } while (RandomCharacters.Length < numberOfLetters);

            return RandomCharacters.ToString();
        }

        /// <summary>Generates some random digits as text.</summary>
        /// <param name="lenght">Length of the string.</param>
        /// <returns>Text containing only digits</returns>
        public static string DigitsAsString(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Lenght cannot be less or equal 0");
            }


            RandomCharacters.Clear();
            
            do
            {
                char character = RandomCharacter(FirstDigitInAscii, LastDigitInAscii);
                // ReSharper disable once RedundantBoolCompare
                if (char.IsDigit(character) == true)
                {
                    RandomCharacters.Append(character);
                }
            } while (RandomCharacters.Length < length);

            return RandomCharacters.ToString();
        }

        /// <summary>Generates some random digits as text.</summary>
        /// <param name="maxRandom">Defines how many characters will be generated.</param>
        /// <returns>Random digits.</returns>
        [Obsolete("This method will be removed in the future. Please use another one with length parameter.")]
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
        /// Generates the date between since and to.
        /// </summary>
        /// <param name="since">Minimum date.</param>
        /// <param name="to">Maximum date.</param>
        /// <returns>Returns the date between values provided.</returns>
        public static DateTime Date(DateTime since, DateTime to)
        {
            if (since > to)
            {
                throw new ArgumentException("Inproper range provided.");
            }

            if (since == to)
            {
                return since;
            }

            double daysDifference = (to - since).TotalDays;
            double randomValue = Double(0, daysDifference);
            return since.AddDays(randomValue);
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
            return randomizer.Next(min, max + 1);
        }

        /// <summary>
        /// Generates only negative integers.
        /// </summary>
        /// <returns>Negative integer.</returns>
        public static int PositiveInteger()
        {
            return randomizer.Next(0, int.MaxValue);
        }

        /// <summary>
        /// Generates only positive integers.
        /// </summary>
        /// <returns>Positive integer.</returns>
        public static int NegativeInteger()
        {
            return randomizer.Next(int.MinValue, 0);
        }

        /// <summary>
        /// Generates some random float.
        /// </summary>
        /// <returns>Random float.</returns>
        public static float Float()
        {
            var someFloat1 = SomeFloat();
            var someFloat2 = SomeFloat();
            if (someFloat2 > someFloat1)
            {
                return someFloat2 - someFloat1;
            }

            return someFloat1 - someFloat2;
        }

        /// <summary>
        /// Returns only positive float number.
        /// </summary>
        /// <returns>Positive float.</returns>
        public static float PositiveFloat()
        {
            return SomeFloat();
        }

        /// <summary>
        /// Returns only negative float number.
        /// </summary>
        /// <returns>Negative float.</returns>
        public static float NegativeFloat()
        {
            return -SomeFloat();
        }

        /// <summary>Generates float from range.</summary>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <returns></returns>
        public static float Float(float min, float max)
        {
            if (min >= max)
            {
                throw new ArgumentException(MinMaxValueExceptionMsg);
            }

            float roundedMin = (float)Math.Round(min + 0.5);
            float roundedMax = (float)Math.Round(max - 0.5);

            if (min >= int.MinValue && max <= int.MaxValue)
            {
                int randomInt = randomizer.Next((int)roundedMin, (int)roundedMax);
                float fraction = (float)randomizer.NextDouble();

                return randomInt + fraction;
            }

            do
            {
                var someFloat = SomeFloat();
                if (someFloat >= min && someFloat <= max)
                {
                    return someFloat;
                }
            } while (true);
        }

        /// <summary>
        /// Returns positive double value.
        /// </summary>
        /// <returns>Positive double.</returns>
        public static double PositiveDouble()
        {
            return SomeDouble();
        }

        public static double NegativeDouble()
        {
            return -SomeDouble();
        }

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
        /// </summary>
        /// <returns>Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.</returns>
        public static double Double()
        {
            var doubleValue1 = SomeDouble();
            var doubleValue2 = SomeDouble();
            if (doubleValue1 >= doubleValue2)
            {
                return doubleValue1 - doubleValue2;
            }

            return doubleValue2 - doubleValue1;
        }

        /// <summary>
        /// Returns some double value within provided range.
        /// </summary>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <returns></returns>
        public static double Double(double min, double max)
        {
            if (min >= max)
            {
                throw new ArgumentException(MinMaxValueExceptionMsg);
            }
            return randomizer.NextDouble() * (max - min) + min;
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
        private static char RandomCharacter(char firstLetter, char lastLetter)
        {
            int randomValue = randomizer.Next(firstLetter, lastLetter);
            char character = (char)randomValue;
            // ReSharper disable once RedundantBoolCompare
            return character;
        }

        #region Private methods

        private static float SomeFloat()
        {
            int expander = randomizer.Next(0, 38);
            int randomValue = randomizer.Next(0, 3);
            float randomFraction = (float)randomizer.Next(0, 4) / 10;
            float randomFloatValue = randomValue + randomFraction;
            return randomFloatValue * randomFloatValue * (float)Math.Pow(10, expander);
        }

        private static double SomeDouble()
        {
            int exponent = randomizer.Next(-308, 308);
            return Math.Pow(10, exponent) * 1.7;
        }

        #endregion Private methods
    }
}


