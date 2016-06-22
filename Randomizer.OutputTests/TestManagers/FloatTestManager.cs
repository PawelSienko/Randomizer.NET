﻿using System.Collections.Generic;
using System.Linq;

namespace Randomizer.OutputTests.TestManagers
{
    public class FloatTestManager : TestManagerBase
    {
        public FloatTestManager(IEnumerable<OutputTestBase> floatInRangeOutputTest, int executionTimes = 0) 
            : base(executionTimes)
        {
            this.executionTimes = executionTimes;
            base.AddExecutable(floatInRangeOutputTest.ToList());
        }
    }
}