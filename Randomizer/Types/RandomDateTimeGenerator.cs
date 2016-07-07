using System;
using Common.Core.Exceptions;
using Randomizer.Interfaces.ValueTypes;

// ReSharper disable once CheckNamespace
namespace Randomizer
{
    public class RandomDateTimeGenerator : RandomGeneratorBase, IRandomDateTime
    {
        public RandomDateTimeGenerator()
        {

        }
        public RandomDateTimeGenerator(int seed)
            : base(seed)
        {

        }

        public DateTime GenerateValue()
        {
            return new DateTime(randomizer.Next(0, int.MaxValue), randomizer.Next(0, 13), randomizer.Next(0, 32));
        }

        public DateTime GenerateValue(DateTime min, DateTime max)
        {
            if (min >= max)
            {
                throw new ArgumentException(Consts.MinMaxValueExceptionMsg);
            }
            
            var randomSecond = randomizer.Next(min.Second, max.Second + 1);
            var randomMinute = randomizer.Next(min.Minute, max.Minute + 1);
            var randomHour = randomizer.Next(min.Hour, max.Hour + 1);
            var randomMiliseconds = randomizer.Next(min.Millisecond, max.Millisecond);

            if (min.Year == max.Year && min.Month == max.Month && min.Day < max.Day)
            {
                var randomDay = randomizer.Next(min.Day, max.Day + 1);
                return new DateTime(min.Year, min.Month, randomDay, randomHour, randomMinute, randomSecond, randomMiliseconds);
            }

            if (min.Year == max.Year && min.Month < max.Month)
            {
                var month = randomizer.Next(min.Month, max.Month + 1);
                var day = RandomDay(min.Year, month);
                return new DateTime(min.Year, month, day, randomHour, randomMinute, randomSecond, randomMiliseconds);
            }

            if (min.Year != max.Year)
            {
                var year = randomizer.Next(min.Year, max.Year + 1);
                var month = randomizer.Next(1, 13);
                var day = RandomDay(min.Year, month);
                return new DateTime(year, month, day, randomHour, randomMinute, randomSecond);
            }
            
            if (min.Hour == max.Hour && min.Minute == max.Minute && min.Second < max.Second)
            {
                var randomSeconds = randomizer.Next(min.Second, max.Second + 1);
                return new DateTime(min.Year, min.Month, min.Day, min.Hour, min.Minute, randomSeconds, randomMiliseconds);
            }

            if (min.Hour == max.Hour && min.Minute < max.Minute)
            {
                var randomMinutes = randomizer.Next(min.Minute, max.Minute + 1);
                return new DateTime(min.Year, min.Month, min.Day, min.Hour, randomMinutes, randomSecond, randomMiliseconds);
            }

            if (min.Hour < max.Hour)
            {
                var randomHours = randomizer.Next(min.Minute, max.Minute + 1);
                return new DateTime(min.Year, min.Month, min.Day, randomHours, randomMinute, randomSecond, randomMiliseconds);
            }

            throw new InvalidStatementException();
        }

        public DateTime GeneratePositiveValue()
        {
            DateTime now = DateTime.Now;
            var randomYear = randomizer.Next(now.Year + 1, DateTime.MaxValue.Year + 1);
            var randomMonth = randomizer.Next(1, 13);
            var randomDay = RandomDay(randomYear, randomMonth);
            return new DateTime(randomYear, randomMonth, randomDay);
        }

        public DateTime GenerateNegativeValue()
        {
            DateTime now = DateTime.Now;

            var randomYear = randomizer.Next(1, now.Year - 1);
            var randomMonth = randomizer.Next(1, 13);
            var randomDay = RandomDay(randomYear, randomMonth);

            return new DateTime(randomYear, randomMonth, randomDay);
        }

        private int RandomDay(int year, int month)
        {
            return randomizer.Next(1, DateTime.DaysInMonth(year, month));
        }

    }
}
