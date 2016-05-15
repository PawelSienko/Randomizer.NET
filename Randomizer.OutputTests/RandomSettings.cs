using System;
using System.Configuration;

namespace Randomizer.OutputTests
{
    public class RandomSettings : ConfigurationSection
    {
        [ConfigurationProperty("randomSettings")]
        [ConfigurationCollection((typeof(RandomSettingCollection)))]
        public RandomSettingCollection RandomSettingCollection
        {
            get { return (RandomSettingCollection)base["randomSettings"]; }
        }
    }

    public class RandomSettingCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new RandomSetting()
            {
                Range = new Range(),
                Type = string.Empty
            };
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element", "Element cannot be null");
            }

            return ((RandomSetting)element).Type;
        }
    }

    public class RandomSetting : ConfigurationElement
    {
        [ConfigurationProperty("type")]
        public string Type { get; set; }

        [ConfigurationProperty("range", IsRequired = false)]
        public Range Range { get; set; }
    }

    public class Range : ConfigurationElement
    {
        [ConfigurationProperty("minValue", DefaultValue = "0", IsRequired = false)]
        public object MinValue { get; set; }
        [ConfigurationProperty("maxValue", DefaultValue = "0", IsRequired = false)]
        public object MaxValue { get; set; }
    }
}
