using System.Collections.Specialized;
using System.Configuration;
using Unity.Utility;

namespace Some.ConfigurationProvider
{
    public class AppConfigProvider : IConfigurationProvider
    {
        /// <summary>
        /// Reads configuration values 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string ReadConfigurationValue(string key)
        {
            Guard.ArgumentNotNullOrEmpty(key, "key");
            string configValue = ConfigurationManager.AppSettings[key];

            return configValue;
        }

        /// <summary>
        /// Reads configuration value from the given section of config file.
        /// </summary>
        /// <param name="sectionName">The name of the section.</param>
        /// <param name="key">The key</param>
        /// <returns>Returned value.</returns>
        public string ReadConfigurationValue(string sectionName, string key)
        {
            Guard.ArgumentNotNullOrEmpty(sectionName, "sectionName");
            Guard.ArgumentNotNullOrEmpty(key, "key");

            NameValueCollection sections = ConfigurationManager.GetSection(sectionName) as NameValueCollection;

            Guard.ArgumentNotNull(sections, "Section which you try to find is null.");
            // ReSharper disable once PossibleNullReferenceException
            return sections[key];
        }
    }
}
