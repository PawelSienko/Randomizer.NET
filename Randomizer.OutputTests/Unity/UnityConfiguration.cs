using System.Collections.Generic;
using System.Configuration;
using Common.Core.Validation;
using Microsoft.Practices.Unity;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.TestManagers;
using Randomizer.OutputTests.Tests;
using Randomizer.OutputTests.Tests.Decimal;
using Randomizer.OutputTests.Tests.Float;
using Randomizer.OutputTests.Tests.Integer;
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
            unity.RegisterType<ILogger, FileLogger>("positiveFloatLog", new InjectionConstructor(basePath, "positiveFloat.log"));
            unity.RegisterType<ILogger, FileLogger>("negativeFloatLog", new InjectionConstructor(basePath, "negativeFloat.log"));

            unity.RegisterType<ILogger, FileLogger>("intInRangeLog", new InjectionConstructor(basePath, "intInRange.log"));
            unity.RegisterType<ILogger, FileLogger>("intPositiveLog", new InjectionConstructor(basePath, "intPositive.log"));
            unity.RegisterType<ILogger, FileLogger>("intNegativeLog", new InjectionConstructor(basePath, "intNegative.log"));

            unity.RegisterType<ILogger, FileLogger>("decimalInRangeLog", new InjectionConstructor(basePath, "decimalInRange.log"));
            unity.RegisterType<ILogger, FileLogger>("decimalPositiveLog", new InjectionConstructor(basePath, "decimalPositive.log"));
            unity.RegisterType<ILogger, FileLogger>("decimalNegativeLog", new InjectionConstructor(basePath, "decimalNegative.log"));

            unity.RegisterType<IRandomFloat, RandomFloatGenerator>();
            unity.RegisterType<IRandomInteger, RandomIntegerGenerator>();
            unity.RegisterType<IRandomDecimal, RandomDecimalGenerator>();

            unity.RegisterType<IOutpuTest, OutputTestBase>();
            unity.RegisterType<IConsoleManager, ConsoleManager>();

            unity.RegisterType<FloatOutputTest, FloatInRangeOutputTest>("float", new InjectionConstructor(new ResolvedParameter(typeof(IRandomFloat))
                , new ResolvedParameter(typeof(ILogger), "floatInRangeLog")));
            unity.RegisterType<FloatOutputTest, FloatPositiveValueOutputTest>("float", new InjectionConstructor(new ResolvedParameter(typeof(IRandomFloat))
                , new ResolvedParameter(typeof(ILogger), "positiveFloatLog")));
            unity.RegisterType<FloatOutputTest, FloatNegativeValueOutputTest>("float", new InjectionConstructor(new ResolvedParameter(typeof(IRandomFloat))
                , new ResolvedParameter(typeof(ILogger), "negativeFloatLog")));

            unity.RegisterType<IntegerOutputTest, IntegerInRangeOutputTest>("integer", new InjectionConstructor(new ResolvedParameter(typeof(IRandomInteger))
                , new ResolvedParameter(typeof(ILogger), "intInRangeLog")));
            unity.RegisterType<IntegerOutputTest, IntegerPositiveValueOutputTest>("integer", new InjectionConstructor(new ResolvedParameter(typeof(IRandomInteger))
                , new ResolvedParameter(typeof(ILogger), "intPositiveLog")));
            unity.RegisterType<IntegerOutputTest, IntegerNegativeValueOutputTest>("integer", new InjectionConstructor(new ResolvedParameter(typeof(IRandomInteger))
                , new ResolvedParameter(typeof(ILogger), "intNegativeLog")));

            unity.RegisterType<DecimalOutputTest, DecimalInRangeOutputTest>("decimal", new InjectionConstructor(new ResolvedParameter(typeof(IRandomDecimal))
                , new ResolvedParameter(typeof(ILogger), "decimalInRangeLog")));
            unity.RegisterType<DecimalOutputTest, DecimalPositiveValueOutputTest>("decimal", new InjectionConstructor(new ResolvedParameter(typeof(IRandomDecimal))
                , new ResolvedParameter(typeof(ILogger), "decimalPositiveLog")));
            unity.RegisterType<DecimalOutputTest, DecimalNegativeValueOutputTest>("decimal", new InjectionConstructor(new ResolvedParameter(typeof(IRandomDecimal))
                , new ResolvedParameter(typeof(ILogger), "decimalNegativeLog")));

            unity.RegisterType<TestManagerBase, FloatTestManager>(new InjectionConstructor(unity.ResolveAll<FloatOutputTest>(), executionNumber));
            unity.RegisterType<TestManagerBase, IntegerTestManager>(new InjectionConstructor(unity.ResolveAll<IntegerOutputTest>(), executionNumber));
            unity.RegisterType<TestManagerBase, DecimalTestManager>(new InjectionConstructor(unity.ResolveAll<DecimalOutputTest>(), executionNumber));
        }

        public static UnityContainer Get
        {
            get { return unity; }
        }
    }
}
