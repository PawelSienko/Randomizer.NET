using System;
using System.Text;

namespace Radlon.Common.RandomProvider
{
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

        static Some()
        {
            RandomCharacters = new StringBuilder();
            randomizer = new Random();
        }

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

        public static DateTime FutureDate()
        {
            DateTime dateTImeNow = DateTime.Now;
            int randomValue = randomizer.Next(1, 1000);
            return dateTImeNow.AddDays(randomValue);
        }

        public static DateTime PastDate()
        {
            DateTime dateTimeNow = DateTime.Now;
            int randomValue = randomizer.Next(1,1000);
            return dateTimeNow.AddDays(-randomValue);
        }

        private static char RandomCharacter(int firstLetter, int lastLetter)
        {
            int randomValue = randomizer.Next(firstLetter, lastLetter);
            char character = (char)randomValue;
            // ReSharper disable once RedundantBoolCompare
            return character;
        }
    }
}


