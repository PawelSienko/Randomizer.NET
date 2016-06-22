﻿using System;
using Common.Core.Exceptions;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.Types
{
    public class RandomDateTimeGenerator : RandomGeneratorBase, IRandomDateTime
    {
        public void InitSeed(int seed)
        {
            randomizer = new Random(seed);
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

            if (min.Year == max.Year && min.Month == max.Month && min.Day < max.Day)
            {
                return new DateTime(min.Year, min.Month, randomizer.Next(min.Day, max.Day + 1));
            }

            if (min.Year == max.Year && min.Month < max.Month)
            {
                return new DateTime(min.Year, randomizer.Next(min.Month, max.Month + 1), randomizer.Next(1, 13));
            }

            if (min.Year != max.Year)
            {
                return new DateTime(randomizer.Next(min.Year, max.Year + 1), randomizer.Next(1, 13), randomizer.Next(1, 32));
            }

            throw new InvalidStatementException();
        }

        public DateTime GeneratePositiveValue()
        {
            DateTime now = DateTime.Now;

            return new DateTime(randomizer.Next(now.Year + 1), randomizer.Next(1, 13), randomizer.Next(1, 32));
        }

        public DateTime GenerateNegativeValue()
        {
            DateTime now = DateTime.Now;

            return new DateTime(randomizer.Next(0, now.Year), randomizer.Next(1, 13), randomizer.Next(1, 32));
        }
    }
}