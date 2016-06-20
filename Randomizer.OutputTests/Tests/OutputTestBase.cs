using System;
using System.Collections;
using System.Collections.Generic;

namespace Randomizer.OutputTests.Tests
{
    public abstract class OutputTestBase : IOutpuTest
    {
        protected ILogger FileLogger;

        public abstract void PerformTest(object min,object max);
    }
}