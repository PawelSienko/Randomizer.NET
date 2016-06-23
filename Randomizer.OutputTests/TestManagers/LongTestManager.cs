using System.Collections.Generic;
using System.Linq;

namespace Randomizer.OutputTests.TestManagers
{
    public class LongTestManager : TestManagerBase
    {
        public LongTestManager(IEnumerable<OutputTestBase> outputTests, int executionTimes = 0) 
            : base(executionTimes)
        {
            this.executionTimes = executionTimes;
            base.AddExecutable(outputTests.ToList());
        }
    }
}