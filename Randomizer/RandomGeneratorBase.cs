using System;

namespace Randomizer
{
    public abstract class RandomGeneratorBase
    {
        // ReSharper disable once InconsistentNaming
        protected Random randomizer;

        protected RandomGeneratorBase()
        {
            randomizer = new Random((int)DateTime.Now.Ticks);
        }

        protected RandomGeneratorBase(int seed)
        {
            randomizer = new Random(seed);
        }

        protected virtual bool IsConditionToReachLimit()
        {
            return DateTime.Now.Ticks % 2016 == 0;
        }
    }
}