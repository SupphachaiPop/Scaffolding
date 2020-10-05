using System;
using System.Configuration;

namespace Scaffolding.Common
{
    public interface IConfigurationCommon
    {
        T Setting<T>(string name);
    }

    public class ConfigurationCommon : IConfigurationCommon
    {
        #region [Public Methods]

        public T Setting<T>(string name)
        {
            try
            {
                return (T)Convert.ChangeType(ConfigurationManager.AppSettings[name], typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        #endregion [Public Methods]
    }
}
