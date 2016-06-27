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
            InvokeTests<IntegerTestManager>("integer", int.MinValue + 10, int.MaxValue - 1);
            InvokeTests<IntegerTestManager>("integers", -70411, 543);
            InvokeTests<FloatTestManager>("float", 1.9023f, 1.924565f);
            InvokeTests<FloatTestManager>("float", -7001.9023f, 21.924565f);
            InvokeTests<FloatTestManager>("float", float.MinValue + 0.01f, float.MaxValue - 0.01);
            InvokeTests<DecimalTestManager>("decimal", 1.2234200045m, 1.32331990989m);
            InvokeTests<DecimalTestManager>("decimal", -1.2234200045m, 500.32331990989m);
            InvokeTests<DecimalTestManager>("decimal", decimal.MinValue + 0.00001m, decimal.MaxValue - 0.0000001m);
            InvokeTests<LongTestManager>("long", -4294967296L, 500000000L);
            InvokeTests<LongTestManager>("long", -4294967296L, -4294967297L);
            InvokeTests<LongTestManager>("long", 4294967296L, 4294967297L);
            InvokeTests<LongTestManager>("long", long.MinValue + 1, long.MaxValue -1);
            InvokeTests<ShortTestManager>("short", -12, 15);
            InvokeTests<ShortTestManager>("short", -100, -15);
            InvokeTests<ShortTestManager>("short", 0, 15);
            InvokeTests<ShortTestManager>("short", short.MinValue - 1, short.MaxValue - 1);
            InvokeTests<DoubleTestManager>("double", double.MinValue + 1, double.MaxValue - 1);
            InvokeTests<DoubleTestManager>("double", -1022342D, 11D);
            InvokeTests<DoubleTestManager>("double", -1022342D, -11D);
            InvokeTests<DoubleTestManager>("double", 1022342D, -1123421312D);
            InvokeTests<DoubleTestManager>("dateTime", DateTime.MinValue.AddYears(20), DateTime.MaxValue.AddYears(-20));
            InvokeTests<DoubleTestManager>("dateTime", DateTime.Now.AddHours(-10), DateTime.Now.AddDays(2));
            InvokeTests<DoubleTestManager>("dateTime", DateTime.Now.AddSeconds(-10), DateTime.Now.AddSeconds(10));
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
