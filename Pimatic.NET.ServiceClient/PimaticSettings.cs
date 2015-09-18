using System.Configuration;
using Pimatic.NET.Contracts.DataTypes.Exceptions;

namespace Pimatic.NET.ServiceClient
{
    //TODO NICOLAS Implement Build Framework so all tests have the same config values
    public static class PimaticSettings
    {
        private static string _get(string key)
        {
            var value = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(value))
                throw new PimaticException("E_PIM_SVC.002", "Could not find application setting with key {0}", key);

            value = value.Trim();
            return value == "" ? null : value;
        }

        public static string Username
        {
            get { return _get("PIMATIC.Username"); }
        }

        public static string Password
        {
            get { return _get("PIMATIC.Password"); }
        }

        public static string Server
        {
            get { return _get("PIMATIC.Server"); }
        }

        public static string Port
        {
            get { return _get("PIMATIC.Port"); }
        }
    }
}

