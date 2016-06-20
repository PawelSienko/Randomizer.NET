using System;

namespace Randomizer.OutputTests
{
    public class ConsoleManager : IConsoleManager
    {
        public void PrintHeader()
        {
            PrintLine("Testing started.....");
        }

        public void PrintFooter()
        {
            PrintLine("Tests finished.....");
            PrintLine("Press any key to exit....");
            Console.ReadLine();
        }

        public void PrintLine(string line)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
