using System;
using System.Collections;
using System.Collections.Generic;

namespace Randomizer.OutputTests.TestManagers
{
    public interface ITestManager
    {
        void AddExecutable(IList<OutputTestBase> executable);
        void ExecuteAll(object min = null,object max = null);
    }
}