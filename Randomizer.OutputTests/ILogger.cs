using System.Collections.Generic;

namespace Randomizer.OutputTests
{
    public interface ILogger
    {
        void LogResult(IEnumerable<string> item);

        void LogResult(string item);
    }
}