using System;
using Common.Core.Exceptions;
using Randomizer.Interfaces.ValueTypes;

// ReSharper disable once CheckNamespace
namespace Randomizer
{
    public class RandomDateTimeGenerator : RandomGenericGeneratorBase<DateTime>, IRandomDateTime
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
            return GetRandomValue();
        }

        public DateTime GenerateValue(DateTime min, DateTime max)
        {
            if (min >= max)
            {
                throw new ArgumentException(Consts.MinMaxValueExceptionMsg);
            }

            if (min.Year == max.Year && min.Month == max.Month && min.Day == max.Day && min.Hour == max.Hour && min.Minute == max.Minute &&
                min.Second == max.Second && min.Millisecond < max.Millisecond)
            {
                var randomMillisecond = randomizer.Next(min.Millisecond, max.Millisecond);
                return new DateTime(min.Year, min.Month, min.Day, min.Hour, min.Minute, min.Second, randomMillisecond);
            }

            if (min.Year == max.Year && min.Month == max.Month && min.Day == max.Day && min.Hour == max.Hour && min.Minute == max.Minute &&
                min.Second < max.Second)
            {
                var randomSecond = randomizer.Next(min.Second, max.Second);
                int randomMillisecond;
                randomMillisecond = randomizer.Next(randomSecond == min.Second ? min.Millisecond : 0, 999);

                return new DateTime(min.Year, min.Month, min.Day, min.Hour, min.Minute, randomSecond, randomMillisecond);
            }

            if (min.Year == max.Year && min.Month == max.Month && min.Day == max.Day && min.Hour == max.Hour && min.Minute < max.Minute)
            {
                return this.RandomSeconds(min, max);
            }

            if (min.Year == max.Year && min.Month == max.Month && min.Day == max.Day && min.Hour < max.Hour)
            {
                return this.RandomMinutes(min, max);
            }


            if (min.Year == max.Year && min.Month == max.Month && min.Day < max.Day)
            {
                return this.RandomHours(min, max);
            }

            if (min.Year == max.Year && min.Month < max.Month)
            {
                return this.RandomDays(min, max);
            }


            if (min.Year < max.Year)
            {
                return this.RandomMonths(min, max);
            }

            throw new InvalidStatementException();
        }

        private DateTime RandomMonths(DateTime min, DateTime max)
        {
            var randomSecond = randomizer.Next(0, 60);
            var randomMillisecond = randomizer.Next(0, 999);
            var randomMinute = randomizer.Next(0, 60);
            var randomHour = randomizer.Next(1, 24);

            int randomMonth;
            var randomYear = randomizer.Next(min.Year, max.Year);

            randomMonth = randomizer.Next(randomYear == min.Year ? min.Month : 1, 12);
            var randomDay = RandomDay(min.Year, randomMonth);

            var randomValue = new DateTime(randomYear, randomMonth, randomDay, randomHour, randomMinute, randomSecond, randomMillisecond);

            if (randomValue < min)
            {
                if (min.Day >= max.Day)
                {
                    var endOfMonth = DateTime.DaysInMonth(min.Year, min.Month);
                    randomDay = randomizer.Next(min.Day, endOfMonth);
                }
                else
                {
                    randomDay = randomizer.Next(min.Day, max.Day);
                }

                randomValue = new DateTime(randomYear, randomMonth, randomDay, randomHour, randomMinute, randomSecond, randomMillisecond);
            }

            if (randomValue < min)
            {
                randomHour = randomizer.Next(min.Hour, 24);
                randomValue = new DateTime(randomYear, randomMonth, randomDay, randomHour, randomMinute, randomSecond, randomMillisecond);
            }

            if (randomValue < min)
            {
                randomMinute = randomizer.Next(min.Minute, 60);
                randomValue = new DateTime(randomYear, randomMonth, randomDay, randomHour, randomMinute, randomSecond, randomMillisecond);
            }

            if (randomValue < min)
            {
                randomSecond = randomizer.Next(min.Second, 60);
                randomValue = new DateTime(randomYear, randomMonth, randomDay, randomHour, randomMinute, randomSecond, randomMillisecond);
            }

            if (randomValue < min)
            {
                randomMillisecond = randomizer.Next(min.Millisecond, 999);
                randomValue = new DateTime(randomYear, randomMonth, randomDay, randomHour, randomMinute, randomSecond, randomMillisecond);
            }

            if (randomValue < min)
            {

            }
            return randomValue;
        }

        private DateTime RandomDays(DateTime min, DateTime max)
        {
            var randomSecond = randomizer.Next(0, 60);
            var randomMillisecond = randomizer.Next(0, 999);
            var randomMinute = randomizer.Next(0, 60);
            var randomHour = randomizer.Next(1, 24);
            int randomDay;

            var randomMonth = randomizer.Next(min.Month, max.Month);

            randomDay = randomizer.Next(min.Day, max.Day);

            var randomValue = new DateTime(min.Year, randomMonth, randomDay, randomHour, randomMinute, randomSecond, randomMillisecond);

            if (randomValue < min)
            {
                randomHour = randomizer.Next(min.Hour, 24);
            }
            randomValue = new DateTime(min.Year, randomMonth, randomDay, randomHour, randomMinute, randomSecond, randomMillisecond);

            if (randomValue < min)
            {
                randomMinute = randomizer.Next(min.Minute, 60);
            }

            randomValue = new DateTime(min.Year, min.Month, randomDay, randomHour, randomMinute, randomSecond, randomMillisecond);

            if (randomValue < min)
            {
                randomSecond = randomizer.Next(min.Second, 60);
            }
            randomValue = new DateTime(min.Year, min.Month, min.Day, randomHour, randomMinute, randomSecond, randomMillisecond);

            if (randomValue < min)
            {
                randomMillisecond = randomizer.Next(min.Millisecond, 999);
            }
            randomValue = new DateTime(min.Year, min.Month, min.Day, randomHour, randomMinute, randomSecond, randomMillisecond);
            return randomValue;
        }

        private DateTime RandomMinutes(DateTime min, DateTime max)
        {
            var randomSecond = randomizer.Next(0, 60);
            var randomMillisecond = randomizer.Next(0, 999);
            int randomMinute;

            var randomHour = randomizer.Next(min.Hour, max.Hour);
            randomMinute = randomizer.Next(randomHour == min.Hour ? min.Minute : 0, 60);

            var randomValue = new DateTime(min.Year, min.Month, min.Day, randomHour, randomMinute, randomSecond, randomMillisecond);
            if (randomValue < min)
            {
                randomSecond = randomizer.Next(min.Second, 60);
            }
            randomValue = new DateTime(min.Year, min.Month, min.Day, randomHour, randomMinute, randomSecond, randomMillisecond);

            if (randomValue < min)
            {
                randomMillisecond = randomizer.Next(min.Millisecond, 999);
            }
            randomValue = new DateTime(min.Year, min.Month, min.Day, randomHour, randomMinute, randomSecond, randomMillisecond);

            return randomValue;
        }

        private DateTime RandomHours(DateTime min, DateTime max)
        {
            var randomSecond = randomizer.Next(0, 60);
            var randomMillisecond = randomizer.Next(0, 999);
            var randomMinute = randomizer.Next(0, 60);
            int randomHour;
            var randomDay = randomizer.Next(min.Day, max.Day);

            randomHour = randomizer.Next(randomDay == min.Day ? min.Hour : 0, 24);

            var randomValue = new DateTime(min.Year, min.Month, randomDay, randomHour, randomMinute, randomSecond, randomMillisecond);

            if (randomValue < min)
            {
                randomMinute = randomizer.Next(min.Minute, 60);
            }

            randomValue = new DateTime(min.Year, min.Month, randomDay, randomHour, randomMinute, randomSecond, randomMillisecond);

            if (randomValue < min)
            {
                randomSecond = randomizer.Next(min.Second, 60);
            }
            randomValue = new DateTime(min.Year, min.Month, min.Day, randomHour, randomMinute, randomSecond, randomMillisecond);

            if (randomValue < min)
            {
                randomMillisecond = randomizer.Next(min.Millisecond, 999);
            }
            randomValue = new DateTime(min.Year, min.Month, min.Day, randomHour, randomMinute, randomSecond, randomMillisecond);
            return randomValue;
        }

        private DateTime RandomSeconds(DateTime min, DateTime max)
        {
            int randomSecond;
            var randomMillisecond = randomizer.Next(0, 999);
            var randomMinute = randomizer.Next(min.Minute, max.Minute);

            randomSecond = randomizer.Next(randomMinute == min.Minute ? min.Second : 0, 60);

            var randomValue = new DateTime(min.Year, min.Month, min.Day, min.Hour, randomMinute, randomSecond, randomMillisecond);
            if (randomValue < min)
            {
                randomSecond = randomizer.Next(min.Second, 60);
            }
            randomValue = new DateTime(min.Year, min.Month, min.Day, min.Hour, randomMinute, randomSecond, randomMillisecond);

            if (randomValue < min)
            {
                randomSecond = randomizer.Next(min.Second, 60);
            }
            randomValue = new DateTime(min.Year, min.Month, min.Day, min.Hour, randomMinute, randomSecond, randomMillisecond);
            if (randomValue < min)
            {
                randomMillisecond = randomizer.Next(min.Millisecond, 999);
            }
            randomValue = new DateTime(min.Year, min.Month, min.Day, min.Hour, randomMinute, randomSecond, randomMillisecond);
            return randomValue;
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

        protected override DateTime GetRandomValue()
        {
            var yearRandomValue = randomizer.Next(0, 9999);
            var monthRandomValue = randomizer.Next(0, 13);
            const int februaryMonthValue = 2;
            var dayRandomValue = default(int);
            if (monthRandomValue == februaryMonthValue)
            {
                dayRandomValue = randomizer.Next(0, 28);
            }
            else
            {
                dayRandomValue = randomizer.Next(0, 32);
            }
            return new DateTime(yearRandomValue, monthRandomValue, dayRandomValue);
        }
    }
}
