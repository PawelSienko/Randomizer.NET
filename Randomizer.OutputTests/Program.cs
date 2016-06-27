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
            InvokeTests<AlphanumericCharTestManager>("alphanumeric char <'g', 'w'>", 'g', 'w');
            InvokeTests<AlphanumericCharTestManager>("alphanumeric char <'A', 'c'>", 'A', 'c');
            InvokeTests<AlphanumericCharTestManager>("alphanumeric char <'c', '4'>", 'c', '4');
            InvokeTests<IntegerTestManager>("integer <10, 20>", 10, 20);
            InvokeTests<IntegerTestManager>("integer <-70411, 543>", -70411, 543);
            InvokeTests<FloatTestManager>("float <1.9023f, 1.924565f>", 1.9023f, 1.924565f);
            InvokeTests<FloatTestManager>("float <-7001.9023f, 21.924565f>", -7001.9023f, 21.924565f);
            InvokeTests<DecimalTestManager>("decimal <1.22342m, 1.32331m>", 1.2234200045m, 1.32331990989m);
            InvokeTests<LongTestManager>("long <-4294967296L, 4294967296L>", -4294967296L, 500000000L);
            InvokeTests<ShortTestManager>("short<-12, 15>", -12, 15);
            InvokeTests<DoubleTestManager>("double <double.MinValue + 100, double.MaxValue - 10000>", double.MinValue + 100, double.MaxValue - 10000);
            InvokeTests<DoubleTestManager>("dateTime <DateTime.MinValue.AddYears(20), DateTime.MaxValue.AddYears(-20)>", DateTime.MinValue.AddYears(20), DateTime.MaxValue.AddYears(-20));
            InvokeTests<AlphanumericStringTestManager>("alphanumeric string");
            consoleManager.PrintFooter();
        }

        private static void InvokeTests<T>(string testName, object min = null, object max = null)
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
