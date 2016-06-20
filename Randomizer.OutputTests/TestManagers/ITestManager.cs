using System;
using System.Collections;

namespace Randomizer.OutputTests.TestManagers
{
    public interface ITestManager
    {
        void AddExecutable(Action<object, object> executable);
        void ExecuteAll(object min = null,object max = null);
    }
}