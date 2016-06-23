using System;
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
using Randomizer.OutputTests.Tests.Long;
using Randomizer.OutputTests.Tests.Short;
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

            RegisterLoggers(basePath);

            unity.RegisterType<IRandomFloat, RandomFloatGenerator>();
            unity.RegisterType<IRandomInteger, RandomIntegerGenerator>();
            unity.RegisterType<IRandomDecimal, RandomDecimalGenerator>();
            unity.RegisterType<IRandomLong, RandomLongGenerator>();
            unity.RegisterType<IRandomShort, RandomShortGenerator>();

            unity.RegisterType<IOutpuTest, OutputTestBase>();
            unity.RegisterType<IConsoleManager, ConsoleManager>();

            RegisterOutputTests();

            unity.RegisterType<TestManagerBase, FloatTestManager>(new InjectionConstructor(unity.ResolveAll<FloatOutputTest>(), executionNumber));
            unity.RegisterType<TestManagerBase, IntegerTestManager>(new InjectionConstructor(unity.ResolveAll<IntegerOutputTest>(), executionNumber));
            unity.RegisterType<TestManagerBase, DecimalTestManager>(new InjectionConstructor(unity.ResolveAll<DecimalOutputTest>(), executionNumber));
            unity.RegisterType<TestManagerBase, LongTestManager>(new InjectionConstructor(unity.ResolveAll<LongOutputTest>(), executionNumber));
            unity.RegisterType<TestManagerBase, ShortTestManager>(new InjectionConstructor(unity.ResolveAll<ShortOutputTest>(), executionNumber));
        }

        private static void RegisterOutputTests()
        {
            RegisterOutputTest(typeof(FloatOutputTest), typeof(FloatInRangeOutputTest), typeof(IRandomFloat), "float",
                "floatInRangeLog");
            RegisterOutputTest(typeof(FloatOutputTest), typeof(FloatPositiveValueOutputTest), typeof(IRandomFloat), "float",
                "positiveFloatLog");
            RegisterOutputTest(typeof(FloatOutputTest), typeof(FloatNegativeValueOutputTest), typeof(IRandomFloat), "float",
                "negativeFloatLog");

            RegisterOutputTest(typeof(IntegerOutputTest), typeof(IntegerInRangeOutputTest), typeof(IRandomInteger), "integer",
                "intInRangeLog");
            RegisterOutputTest(typeof(IntegerOutputTest), typeof(IntegerPositiveValueOutputTest), typeof(IRandomInteger), "integer",
                "intPositiveLog");
            RegisterOutputTest(typeof(IntegerOutputTest), typeof(IntegerNegativeValueOutputTest), typeof(IRandomInteger), "integer",
                "intNegativeLog");

            RegisterOutputTest(typeof(DecimalOutputTest), typeof(DecimalInRangeOutputTest), typeof(IRandomDecimal), "decimal",
                "decimalInRangeLog");
            RegisterOutputTest(typeof(DecimalOutputTest), typeof(DecimalPositiveValueOutputTest), typeof(IRandomDecimal), "decimal",
                "decimalPositiveLog");
            RegisterOutputTest(typeof(DecimalOutputTest), typeof(DecimalNegativeValueOutputTest), typeof(IRandomDecimal), "decimal",
                "decimalNegativeLog");

            RegisterOutputTest(typeof(LongOutputTest), typeof(LongInRangeOutputTest), typeof(IRandomLong), "long",
               "longInRangeLog");
            RegisterOutputTest(typeof(LongOutputTest), typeof(LongPositiveValueOutputTest), typeof(IRandomLong), "long",
                "longPositiveLog");
            RegisterOutputTest(typeof(LongOutputTest), typeof(LongNegativeValueOutputTest), typeof(IRandomLong), "long",
                "longNegativeLog");

            RegisterOutputTest(typeof(ShortOutputTest), typeof(ShortInRangeOutputTest), typeof(IRandomShort), "short",
               "shortInRangeLog");
            RegisterOutputTest(typeof(ShortOutputTest), typeof(ShortPositiveValueOutputTest), typeof(IRandomShort), "short",
                "shortPositiveLog");
            RegisterOutputTest(typeof(ShortOutputTest), typeof(ShortNegativeValueOutputTest), typeof(IRandomShort), "short",
                "shortNegativeLog");
        }

        private static void RegisterOutputTest(Type baseType, Type concreteType, Type randomInputInterface,
            string registerName, string loggerRegisterName)
        {
            unity.RegisterType(baseType, concreteType, registerName, new InjectionConstructor(new ResolvedParameter(randomInputInterface)
                , new ResolvedParameter(typeof(ILogger), loggerRegisterName)));
        }

        private static void RegisterLoggers(string basePath)
        {

            RegisterLogger("floatInRangeLog", "floatInRange.log", basePath);
            RegisterLogger("positiveFloatLog", "positiveFloat.log", basePath);
            RegisterLogger("negativeFloatLog", "negativeFloat.log", basePath);

            RegisterLogger("intInRangeLog", "intInRange.log", basePath);
            RegisterLogger("intPositiveLog", "intPositive.log", basePath);
            RegisterLogger("intNegativeLog", "intNegative.log", basePath);

            RegisterLogger("decimalInRangeLog", "decimalInRange.log", basePath);
            RegisterLogger("decimalPositiveLog", "decimalPositive.log", basePath);
            RegisterLogger("decimalNegativeLog", "decimalNegative.log", basePath);

            RegisterLogger("longInRangeLog", "longInRange.log", basePath);
            RegisterLogger("longPositiveLog", "longPositive.log", basePath);
            RegisterLogger("longNegativeLog", "longNegative.log", basePath);

            RegisterLogger("shortInRangeLog", "shortInRange.log", basePath);
            RegisterLogger("shortPositiveLog", "shortPositive.log", basePath);
            RegisterLogger("shortNegativeLog", "shortNegative.log", basePath);
        }

        private static void RegisterLogger(string registerName, string logFileName, string basePath)
        {
            unity.RegisterType<ILogger, FileLogger>(registerName, new InjectionConstructor(basePath, logFileName));
        }
        public static UnityContainer Get
        {
            get { return unity; }
        }
    }
}
