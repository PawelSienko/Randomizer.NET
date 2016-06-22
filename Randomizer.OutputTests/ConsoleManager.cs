using System;

namespace Randomizer.OutputTests
{
    public class ConsoleManager : IConsoleManager
    {
        public void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintLine("Testing started.....");
        }

        public void PrintFooter()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintLine("Tests finished.....");
            PrintLine("Press any key to exit....");
            Console.ReadLine();
        }

        public void PrintLine(string line)
        {
            Console.ForegroundColor = ForegroundColor;
            Console.WriteLine(line);;
        }

        public ConsoleColor ForegroundColor
        {
            get { return Console.ForegroundColor; }
            set { Console.ForegroundColor = value; }
        }
    }
}
