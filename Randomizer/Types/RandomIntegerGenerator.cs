using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Interfaces;
using Randomizer.Interfaces.ValueTypes;

namespace Randomizer.Types
{
    public class RandomIntegerGenerator : RandomGeneratorBase, IRandomInteger
    {
        public void InitSeed(int seed)
        {
            this.randomizer = new Random(seed);
        }

        public int GenerateValue()
        {
            return randomizer.Next();
        }

        public int GenerateValue(int min, int max)
        {
            if (min > max)
            {
                throw new ArgumentException("Min cannot be greater than max.");
            }

            return randomizer.Next(min, max);
        }

        public int GeneratePositiveValue()
        {
            return randomizer.Next(0, int.MaxValue);
        }

        public int GenerateNegativeValue()
        {
            return randomizer.Next(int.MinValue, 0);
        }
    }
}
