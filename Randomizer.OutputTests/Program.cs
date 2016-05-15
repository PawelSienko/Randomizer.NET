using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer.Interfaces;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.Types;

namespace Randomizer.OutputTests
{
    class Program
    {
        private static string path;
        private static string errorPath;
        private static int numberAmount;

        static void Main(string[] args)
        {
            Init();
            //ProcessFloat();
            //ProcessFloatWithRange();
            ShowLnForTicks();
            Console.WriteLine("Press any key to exit..");
            Console.ReadLine();
        }

        /// <summary>
        /// Shows numbers for natural logarithm.
        /// </summary>
        private static void ShowLnForTicks()
        {
            WriteConsoleMsg("Ln - generating ....");
            for (int i = 0; i < 10000000; i++)
            {
                long ticks = DateTime.Now.Ticks;

                if (ticks % 2016 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Generated");
                    SaveToFile(ticks.ToString(CultureInfo.InvariantCulture) + Environment.NewLine, "C:\\Temp\\exp.txt");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            WriteConsoleMsg("Float - finished!");
        }

        private static void Init()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            path = ConfigurationManager.AppSettings["Path"];
            errorPath = ConfigurationManager.AppSettings["ErrorPath"];
            ValidateStringNullOrEmpty(path);
            string numberAmountAsString = ConfigurationManager.AppSettings["numberAmount"];
            ValidateStringNullOrEmpty(numberAmountAsString);
            bool result = int.TryParse(numberAmountAsString, out numberAmount);
            if (result == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new ArgumentException("Could not parse string to digit.");
            }
            File.Delete(errorPath);
            File.Delete(path + "float.txt");
            File.Delete(path + "floatWithRange.txt");
        }

        private static void ProcessFloat()
        {
            WriteConsoleMsg("Float - generating ....");
            GenerateFloat();
            WriteConsoleMsg("Float - finished!");
        }

        private static void ProcessFloatWithRange()
        {
            var floatRandomSetting = GetRandomSettingByKey("floatWithRange");
            float min = (float)floatRandomSetting.Range.MinValue;
            float max = (float)floatRandomSetting.Range.MaxValue;

            WriteConsoleMsg("Float with range - generating ....");
            GenerateFloatWithRange(min, max);
            WriteConsoleMsg("FLoat with range- finished!");
        }

        private static RandomSetting GetRandomSettingByKey(string key)
        {
            var randomSettings = ConfigurationManager.GetSection("randomSettings");
            var floatRandomSettings = ((RandomSettings)randomSettings).RandomSettingCollection;
            foreach (RandomSetting floatRandomSetting in floatRandomSettings)
            {
                if (floatRandomSetting.Type == key)
                {
                    return floatRandomSetting;
                }
            }

            return null;
        }

        private static void WriteConsoleMsg(string message)
        {
            Console.WriteLine(message);
        }

        private static void ValidateStringNullOrEmpty(string argument)
        {
            if (string.IsNullOrEmpty(argument))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new ArgumentNullException("argument", "Argument cannot be null.");
            }
        }

        private static void GenerateFloatWithRange(float min, float max)
        {
            var floatNumbers = GenerateRandomFloatValues(min, max);
            string floatText = Convert(floatNumbers);
            SaveToFile(floatText, path + "floatWithRange.txt");
        }

        private static void GenerateFloat()
        {
            var floatNumbers = GenerateRandomFloatValues();
            string floatText = Convert(floatNumbers);
            SaveToFile(floatText, path + "float.txt");
        }

        private static IEnumerable<float> GenerateRandomFloatValues(float min = float.MinValue, float max = float.MaxValue)
        {
            List<float> floatNumbers = new List<float>();
            IRandomFloat randomFloat = new RandomFloatGenerator();
            randomFloat.InitSeed((int)DateTime.Now.Ticks);
            for (int i = 0; i < numberAmount; i++)
            {
                float generatedValue = randomFloat.GenerateValue(min, max);
                if (generatedValue < min || generatedValue > max)
                {
                    SaveToFile(string.Format("GenerateRandomFloatValues : min: {0}, max {1}, generated valye: {2}\n", min, max, generatedValue), errorPath);
                }
                floatNumbers.Add(generatedValue);
            }
            return floatNumbers;
        }

        private static void SaveToFile(string content, string diskPath)
        {
            File.AppendAllText(diskPath, content);
        }

        private static string Convert<TType>(IEnumerable<TType> collectionOfItems)
        {
            StringBuilder builder = new StringBuilder();
            collectionOfItems.ToList().ForEach(item =>
            {
                builder.AppendLine(item.ToString());
            });

            return builder.ToString();
        }
    }
}
