using System;

namespace Randomizer
{
    public abstract class RandomGeneratorBase
    {
        // ReSharper disable once InconsistentNaming
        protected Random randomizer;

        protected virtual bool IsConditionToReachLimit()
        {
            return DateTime.Now.Ticks % 2016 == 0;
        }
    }
}