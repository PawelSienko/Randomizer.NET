using System.Configuration;
using Common.Core.Validation;
using Microsoft.Practices.Unity;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.TestManagers;
using Randomizer.OutputTests.Tests;
using Randomizer.Types;

namespace Randomizer.OutputTests.Unity
{
    public static class UnityConfiguration
    {
        private static UnityContainer unity;

        public static void Configure()
        {
            string basePath = ConfigurationManager.AppSettings["basePath"];
            int executionNumber = int.Parse(ConfigurationManager.AppSettings["executionNumber"]);

            Validator.ValidateNullOrEmpty(basePath);

            unity = new UnityContainer();

            unity.RegisterType<ILogger, FileLogger>("floatInRangeLog", new InjectionConstructor(basePath, "floatInRange.log"));
            unity.RegisterType<IRandomFloat, RandomFloatGenerator>();
            unity.RegisterType<IOutpuTest, OutputTestBase>();
            unity.RegisterType<IConsoleManager, ConsoleManager>();
            unity.RegisterType<OutputTestBase, FloatInRangeOutputTest>(new InjectionConstructor(new ResolvedParameter(typeof(IRandomFloat))
                , new ResolvedParameter(typeof(ILogger), "floatInRangeLog"), executionNumber));
            unity.RegisterType<TestManagerBase, FloatTestManager>(new InjectionConstructor(new ResolvedParameter(typeof(FloatInRangeOutputTest))));
        }

        public static UnityContainer Get
        {
            get { return unity; }
        }
    }
}
