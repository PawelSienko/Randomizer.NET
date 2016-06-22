using System;
using System.Collections.Generic;
using System.Linq;
using Common.Core.Validation;
using Microsoft.Practices.ObjectBuilder2;
using Randomizer.OutputTests.TestManagers;

namespace Randomizer.OutputTests
{
    public class TestManagerBase : ITestManager
    {
        private readonly List<OutputTestBase> executables;

        protected int executionTimes;

        public TestManagerBase(int executionTimes = 0)
        {
            if (executionTimes != 0)
            {
                this.executionTimes = executionTimes;
            }

            executables = new List<OutputTestBase>();
        }

        public void AddExecutable(IList<OutputTestBase> executable)
        {
            Validator.ValidateNull(executable);
            if (executionTimes != 0)
            {
                executable.ForEach(ex =>
                {
                    ex.ExecutionTimes = executionTimes;
                });
            }

            executables.AddRange(executable);
        }

        public void ExecuteAll(object min = null, object max = null)
        {
            executables.ForEach(ex =>
            {
                ex.PerformTest(min, max);
            });
        }
    }
}
