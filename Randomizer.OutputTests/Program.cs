using System;
using System.Runtime.CompilerServices;
using Microsoft.Practices.Unity;
using Randomizer.OutputTests.TestManagers;
using Randomizer.OutputTests.Unity;

namespace Randomizer.OutputTests
{
    class Program
    {
        private static IConsoleManager consoleManager;

        static Program()
        {
            Bootstrap();
        }

        static void Main(string[] args)
        {
            consoleManager.PrintHeader();
            Console.ForegroundColor = ConsoleColor.Green;
            InvokeTests<AlphanumericCharTestManager>("alphanumeric char", 'g', 'w');
            InvokeTests<AlphanumericCharTestManager>("alphanumeric char", 'F', 'L');
            InvokeTests<AlphanumericCharTestManager>("alphanumeric char", 'A', 'c');
            InvokeTests<AlphanumericCharTestManager>("alphanumeric char", 'c', '4');
            InvokeTests<AlphanumericCharTestManager>("alphanumeric char", 'A', '1');
            InvokeTests<IntegerTestManager>("integer", 10, 20);
            InvokeTests<IntegerTestManager>("integer", int.MinValue, int.MaxValue);
            InvokeTests<IntegerTestManager>("integers", -70411, 543);
            InvokeTests<FloatTestManager>("float", 1.9023f, 1.924565f);
            InvokeTests<FloatTestManager>("float", -7001.9023f, 21.924f);
            InvokeTests<FloatTestManager>("float", float.MinValue, float.MaxValue);
            InvokeTests<DecimalTestManager>("decimal", 1.2234200045m, 1.32331990989m);
            InvokeTests<DecimalTestManager>("decimal", -1.2234200045m, 500.32331990989m);
            InvokeTests<DecimalTestManager>("decimal", decimal.MinValue, decimal.MaxValue);
            InvokeTests<LongTestManager>("long", -4294967296L, 500000000L);
            InvokeTests<LongTestManager>("long", -4294967297L, -4294967295L);
            InvokeTests<LongTestManager>("long", 4294967296L, 4294967297L);
            InvokeTests<LongTestManager>("long", long.MinValue, long.MaxValue);
            InvokeTests<ShortTestManager>("short", (short)-12, (short)15);
            InvokeTests<ShortTestManager>("short", (short)-100, (short)-15);
            InvokeTests<ShortTestManager>("short", (short)0, (short)15);
            InvokeTests<ShortTestManager>("short", short.MinValue, short.MaxValue);
            InvokeTests<DoubleTestManager>("double", double.MinValue, double.MaxValue);
            InvokeTests<DoubleTestManager>("double", -1022342D, 11D);
            InvokeTests<DoubleTestManager>("double", -1022342D, -11D);
            InvokeTests<DoubleTestManager>("double", 1022342D, 1123421312D);
            //InvokeTests<DateTimeTestManager>("dateTime", DateTime.MinValue.AddMinutes(1), DateTime.MaxValue.AddMinutes(-1));
            //InvokeTests<DateTimeTestManager>("dateTime", DateTime.Now.AddHours(-10), DateTime.Now.AddDays(2));
            //InvokeTests<DateTimeTestManager>("dateTime", DateTime.Now.AddMilliseconds(-10), DateTime.Now.AddMilliseconds(10));
            InvokeTests<AlphanumericStringTestManager>("alphanumeric string");
            consoleManager.PrintFooter();
        }

        private static void InvokeTests<T>(string testName, object min = null, object max = null)
            where T : TestManagerBase
        {
            consoleManager.PrintLine($"Start {testName} <{min},{max}>tests..............");
            UnityConfiguration.Get.Resolve<T>().ExecuteAll(min, max);
            consoleManager.PrintLine($"Stop {testName} tests..............");
        }

        private static void Bootstrap()
        {
            UnityConfiguration.Configure();
            consoleManager = UnityConfiguration.Get.Resolve<IConsoleManager>();
        }

    }
}
