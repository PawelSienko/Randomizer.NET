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
            consoleManager.PrintFooter();
        }

        private static void InvokeTests<T>(string testName, object min, object max)
            where T : TestManagerBase
        {
            consoleManager.PrintLine($"Start {testName} tests..............");
            UnityConfiguration.Get.Resolve<T>().ExecuteAll(min, max);
            consoleManager.PrintLine($"Start {testName} tests..............");
        }
        
        private static void Bootstrap()
        {
            UnityConfiguration.Configure();
            consoleManager = UnityConfiguration.Get.Resolve<IConsoleManager>();
        }

    }
}
