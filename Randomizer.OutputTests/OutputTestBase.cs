using System;
using System.Collections.Generic;

namespace Randomizer.OutputTests
{
    public abstract class OutputTestBase : IOutpuTest
    {
        protected List<string> wrongResults;

        protected OutputTestBase()
        {
            this.wrongResults = new List<string>();
        }

        protected ILogger FileLogger;

        public virtual void ValidateConfitions()
        {
            if (ExecutionTimes == 0)
            {
                throw new ArgumentException("Execution times should be greater than 0");
            }
        }

        public abstract void PerformTest(object min = null, object max = null);
        
        public int ExecutionTimes { get; set; }
    }
}