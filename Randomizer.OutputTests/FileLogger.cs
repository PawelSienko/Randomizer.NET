using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common.Core.Validation;

namespace Randomizer.OutputTests
{
    public class FileLogger : ILogger
    {
        private readonly string fullPath;

        public FileLogger(string basePath, string fileName)
        {
            Validator.ValidateNullOrEmpty(basePath);
            Validator.ValidateNullOrEmpty(fileName);
            if (Directory.Exists(basePath) == false)
            {
                Directory.CreateDirectory(basePath);
            }

            fullPath = Path.Combine(basePath, fileName);
        }

        public void LogResult(IEnumerable<string> lines)
        {
            if (lines != null && lines.Any())
            {
                File.AppendAllLines(fullPath, lines);
            }
        }

        public void LogResult(string singleLine)
        {
            if (string.IsNullOrEmpty(singleLine) == false)
            {
                File.AppendAllText(fullPath, singleLine);
            }
        }
    }
}