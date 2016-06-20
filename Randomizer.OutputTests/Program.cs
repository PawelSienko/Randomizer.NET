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

            FloatInRange();

            consoleManager.PrintFooter();
        }

        private static void FloatInRange()
        {
            consoleManager.PrintLine("Start Float in range..............");
            UnityConfiguration.Get.Resolve<FloatTestManager>().ExecuteAll(1.9023f, 1.924565f);
            consoleManager.PrintLine("Stop float in range");
        }

        private static void Bootstrap()
        {
            UnityConfiguration.Configure();
            consoleManager = UnityConfiguration.Get.Resolve<IConsoleManager>();
        }

    }
}
