using System.Collections.Generic;
using System.Linq;

namespace Randomizer.OutputTests.TestManagers
{
    public class IntegerTestManager : TestManagerBase
    {
        public IntegerTestManager(IEnumerable<OutputTestBase> integerTests, int executionTimes = 0)
        {

            this.executionTimes = executionTimes;
            base.AddExecutable(integerTests.ToList());
        }
    }
}