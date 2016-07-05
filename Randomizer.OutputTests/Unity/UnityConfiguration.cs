using System;
using System.Configuration;
using Common.Core.Validation;
using Microsoft.Practices.Unity;
using Randomizer.Interfaces.ReferenceTypes;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.TestManagers;
using Randomizer.OutputTests.Tests.AlphanumericChar;
using Randomizer.OutputTests.Tests.AlphanumericString;
using Randomizer.OutputTests.Tests.DateTime;
using Randomizer.OutputTests.Tests.Decimal;
using Randomizer.OutputTests.Tests.Double;
using Randomizer.OutputTests.Tests.Float;
using Randomizer.OutputTests.Tests.Integer;
using Randomizer.OutputTests.Tests.Long;
using Randomizer.OutputTests.Tests.Short;

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
            unity.RegisterType<IRandomFloat, RandomFloatGenerator>(new InjectionConstructor());
            unity.RegisterType<IRandomInteger, RandomIntegerGenerator>(new InjectionConstructor());
            unity.RegisterType<IRandomDecimal, RandomDecimalGenerator>(new InjectionConstructor());
            unity.RegisterType<IRandomLong, RandomLongGenerator>(new InjectionConstructor());
            unity.RegisterType<IRandomShort, RandomShortGenerator>(new InjectionConstructor());
            unity.RegisterType<IRandomDouble, RandomDoubleGenerator>(new InjectionConstructor());
            unity.RegisterType<IRandomDateTime, RandomDateTimeGenerator>(new InjectionConstructor());

            unity.RegisterType<IRandomAlphanumericString, RandomAlphanumericStringGenerator>(new InjectionConstructor());
            unity.RegisterType<IRandomCharacter, RandomAlphanumericCharGenerator>(new InjectionConstructor());

            unity.RegisterType<IOutpuTest, OutputTestBase>();
            unity.RegisterType<IConsoleManager, ConsoleManager>();

            RegisterOutputTests();
            
            unity.RegisterType<TestManagerBase, FloatTestManager>(new InjectionConstructor(unity.ResolveAll<FloatOutputTest>(), executionNumber));
            unity.RegisterType<TestManagerBase, IntegerTestManager>(new InjectionConstructor(unity.ResolveAll<IntegerOutputTest>(), executionNumber));
            unity.RegisterType<TestManagerBase, DecimalTestManager>(new InjectionConstructor(unity.ResolveAll<DecimalOutputTest>(), executionNumber));
            unity.RegisterType<TestManagerBase, LongTestManager>(new InjectionConstructor(unity.ResolveAll<LongOutputTest>(), executionNumber));
            unity.RegisterType<TestManagerBase, ShortTestManager>(new InjectionConstructor(unity.ResolveAll<ShortOutputTest>(), executionNumber));
            unity.RegisterType<TestManagerBase, DoubleTestManager>(new InjectionConstructor(unity.ResolveAll<DoubleOutputTest>(), executionNumber));
            unity.RegisterType<TestManagerBase, DateTimeTestManager>(new InjectionConstructor(unity.ResolveAll<DateTimeOutputTest>(), executionNumber));
            unity.RegisterType<TestManagerBase, AlphanumericStringTestManager>(new InjectionConstructor(unity.ResolveAll<AlphanumericStringOutputTest>(), executionNumber));
            unity.RegisterType<TestManagerBase, AlphanumericCharTestManager>(new InjectionConstructor(unity.ResolveAll<AlphanumericCharOutputTest>(), executionNumber));
        }

        private static void RegisterOutputTests()
        {
            RegisterOutputTest(typeof(FloatOutputTest), typeof(FloatInRangeOutputTest), typeof(IRandomFloat), "floatInRange",
                "floatInRangeLog");
            RegisterOutputTest(typeof(FloatOutputTest), typeof(FloatPositiveValueOutputTest), typeof(IRandomFloat), "floatPositive",
                "positiveFloatLog");
            RegisterOutputTest(typeof(FloatOutputTest), typeof(FloatNegativeValueOutputTest), typeof(IRandomFloat), "floatNegative",
                "negativeFloatLog");

            RegisterOutputTest(typeof(IntegerOutputTest), typeof(IntegerInRangeOutputTest), typeof(IRandomInteger), "integerInRange",
                "intInRangeLog");
            RegisterOutputTest(typeof(IntegerOutputTest), typeof(IntegerPositiveValueOutputTest), typeof(IRandomInteger), "integerPositive",
                "intPositiveLog");
            RegisterOutputTest(typeof(IntegerOutputTest), typeof(IntegerNegativeValueOutputTest), typeof(IRandomInteger), "integerNegative",
                "intNegativeLog");

            RegisterOutputTest(typeof(DecimalOutputTest), typeof(DecimalInRangeOutputTest), typeof(IRandomDecimal), "decimalInRange",
                "decimalInRangeLog");
            RegisterOutputTest(typeof(DecimalOutputTest), typeof(DecimalPositiveValueOutputTest), typeof(IRandomDecimal), "decimalPositive",
                "decimalPositiveLog");
            RegisterOutputTest(typeof(DecimalOutputTest), typeof(DecimalNegativeValueOutputTest), typeof(IRandomDecimal), "decimalNegative",
                "decimalNegativeLog");

            RegisterOutputTest(typeof(LongOutputTest), typeof(LongInRangeOutputTest), typeof(IRandomLong), "longInRangte",
               "longInRangeLog");
            RegisterOutputTest(typeof(LongOutputTest), typeof(LongPositiveValueOutputTest), typeof(IRandomLong), "longPositive",
                "longPositiveLog");
            RegisterOutputTest(typeof(LongOutputTest), typeof(LongNegativeValueOutputTest), typeof(IRandomLong), "longNegative",
                "longNegativeLog");

            RegisterOutputTest(typeof(ShortOutputTest), typeof(ShortInRangeOutputTest), typeof(IRandomShort), "shortInRange",
               "shortInRangeLog");
            RegisterOutputTest(typeof(ShortOutputTest), typeof(ShortPositiveValueOutputTest), typeof(IRandomShort), "shortPositive",
                "shortPositiveLog");
            RegisterOutputTest(typeof(ShortOutputTest), typeof(ShortNegativeValueOutputTest), typeof(IRandomShort), "shortNegative",
                "shortNegativeLog");

            RegisterOutputTest(typeof(DoubleOutputTest), typeof(DoubleInRangeOutputTest), typeof(IRandomDouble), "doubleInRange",
               "shortInRangeLog");
            RegisterOutputTest(typeof(DoubleOutputTest), typeof(DoublePositiveValueOutputTest), typeof(IRandomDouble), "doublePositive",
                "shortPositiveLog");
            RegisterOutputTest(typeof(DoubleOutputTest), typeof(DoubleNegativeValueOutputTest), typeof(IRandomDouble), "doubleNegative",
                "shortNegativeLog");

            RegisterOutputTest(typeof(DateTimeOutputTest), typeof(DateTimeInRangeOutputTest), typeof(IRandomDateTime), "dateTimeInRange",
               "dateTimeInRangeLog");
            RegisterOutputTest(typeof(DateTimeOutputTest), typeof(DateTimePositiveValueOutputTest), typeof(IRandomDateTime), "dateTimePositive",
                "dateTimePositiveLog");
            RegisterOutputTest(typeof(DateTimeOutputTest), typeof(DateTimeNegativeValueOutputTest), typeof(IRandomDateTime), "dateTimeNegative",
                "dateTimeNegativeLog");

            RegisterOutputTest(typeof(AlphanumericStringOutputTest), typeof(AlphanumericStringDefaultLengthOutputTest), typeof(IRandomAlphanumericString), "alphanumericStringDefault",
              "stringDefaultLengthLog");
            RegisterOutputTest(typeof(AlphanumericStringOutputTest), typeof(AlphanumericStringFixedLengthOutputTest), typeof(IRandomAlphanumericString), "alphanumericStringFixed",
                "stringFixedLengthLog");
            RegisterOutputTest(typeof(AlphanumericStringOutputTest), typeof(AlphanumericStringLowercaseOutputTest), typeof(IRandomAlphanumericString), "alphanumericStringLower",
                "stringLowercaseLog");
            RegisterOutputTest(typeof(AlphanumericStringOutputTest), typeof(AlphanumericStringUppercaseOutputTest), typeof(IRandomAlphanumericString), "alphanumericStringUpper",
                "stringUppercaseLog");

            RegisterOutputTest(typeof(AlphanumericCharOutputTest), typeof(AlphanumericRandomCharOutputTest), typeof(IRandomCharacter), "charDefault",
              "randomCharacterLog");
            RegisterOutputTest(typeof(AlphanumericCharOutputTest), typeof(AlphanumericCharInRangeOutputTest), typeof(IRandomCharacter), "charInRange",
                "randomCharacterInRangeLog");
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

            RegisterLogger("doubleInRangeLog", "doubleInRange.log", basePath);
            RegisterLogger("doublePositiveLog", "doublePositive.log", basePath);
            RegisterLogger("doubleNegativeLog", "doubleNegative.log", basePath);

            RegisterLogger("dateTimeInRangeLog", "dateTimeInRange.log", basePath);
            RegisterLogger("dateTimePositiveLog", "dateTimePositive.log", basePath);
            RegisterLogger("dateTimeNegativeLog", "dateTimeNegative.log", basePath);

            RegisterLogger("stringDefaultLengthLog", "stringDefaultLength.log", basePath);
            RegisterLogger("stringFixedLengthLog", "stringFixedLength.log", basePath);
            RegisterLogger("stringLowercaseLog", "stringLowercase.log", basePath);
            RegisterLogger("stringUppercaseLog", "stringUppercase.log", basePath);

            RegisterLogger("randomCharacterLog", "randomCharacter.log", basePath);
            RegisterLogger("randomCharacterInRangeLog", "randomCharacter.log", basePath);
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
