using System;
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
            InvokeTests<IntegerTestManager>("integer", 10, 20);
            InvokeTests<FloatTestManager>("float", 1.9023f, 1.924565f);
            InvokeTests<DecimalTestManager>("decimal", 1.22342m, 1.32331m);
            InvokeTests<LongTestManager>("long", -4294967296L, 4294967296L);
            InvokeTests<ShortTestManager>("short", -12, 15);
            InvokeTests<DoubleTestManager>("double", double.MinValue + 100, double.MaxValue - 10000);
            consoleManager.PrintFooter();
        }

        private static void InvokeTests<T>(string testName, object min, object max)
            where T : TestManagerBase
        {
            consoleManager.PrintLine($"Start {testName} tests..............");
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
