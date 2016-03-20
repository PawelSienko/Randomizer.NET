namespace Radlon.Common.ConfigurationProvider
{
    public interface IConfigurationProvider
    {
        /// <summary>
        /// Reads configuration value from appSettings of config file.
        /// </summary>
        /// <param name="key">Configuration key</param>
        /// <returns>Configuration value</returns>
        string ReadConfigurationValue(string key);

        string ReadConfigurationValue(string sectionName, string key);
    }
}
