using System.Collections.Generic;
using System.Linq;

namespace Randomizer.OutputTests.TestManagers
{
    public class ShortTestManager : TestManagerBase
    {
        public ShortTestManager(IEnumerable<OutputTestBase> outputTests, int executionTimes = 0) 
            : base(executionTimes)
        {
            this.executionTimes = executionTimes;
            base.AddExecutable(outputTests.ToList());
        }
    }
}