using System.Collections.Generic;
using System.Linq;

namespace Randomizer.OutputTests.TestManagers
{
    public class AlphanumericCharTestManager : TestManagerBase
    {
        public AlphanumericCharTestManager(IEnumerable<OutputTestBase> outputTests, int executionTimes = 0) 
            : base(executionTimes)
        {
            this.executionTimes = executionTimes;
            base.AddExecutable(outputTests.ToList());
        }
    }
}