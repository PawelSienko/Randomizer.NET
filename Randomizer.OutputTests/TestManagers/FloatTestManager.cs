using Microsoft.Practices.Unity;
using Randomizer.OutputTests.Tests;

namespace Randomizer.OutputTests.TestManagers
{
    public class FloatTestManager : TestManagerBase
    {
        public FloatTestManager(OutputTestBase floatInRangeOutputTest)
        {
            base.AddExecutable(floatInRangeOutputTest.PerformTest);
        }
    }
}