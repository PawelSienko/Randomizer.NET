using System;
using System.Collections.Generic;
using Common.Core.Validation;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;

namespace Randomizer.OutputTests.TestManagers
{
    public class TestManagerBase : ITestManager
    {
        private readonly IList<Action<object,object>> executables;

        public TestManagerBase()
        {
            executables = new List<Action<object, object>>();
        }

        public void AddExecutable(Action<object, object> executable)
        {
            Validator.ValidateNull(executable);
            executables.Add(executable);
        }

        public void ExecuteAll(object min = null, object max = null)
        {
            executables.ForEach(ex =>
            {
                ex(min,max);
            });
        }
    }
}
