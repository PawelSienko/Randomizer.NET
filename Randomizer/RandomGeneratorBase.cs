using System;

namespace Randomizer
{
    public abstract class RandomGeneratorBase
    {
        protected Random randomizer;

        protected virtual bool IsConditionToReachLimit()
        {
            return DateTime.Now.Ticks % 2016 == 0;
        }
    }
}