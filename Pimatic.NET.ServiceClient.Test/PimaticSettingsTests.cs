using System.Configuration;
using NUnit.Framework;
using Pimatic.NET.ServiceClient.Test.Attributes;

namespace Pimatic.NET.ServiceClient.Test
{
    [TestFixture]
    public class PimaticSettingsTests
    {
        private string _username;
        private string _password;
        private string _server;
        private string _port;

        [SetUp]
        public void SetUp()
        {
            _username = ConfigurationManager.AppSettings["PIMATIC.Username"];
            _password = ConfigurationManager.AppSettings["PIMATIC.Password"];
            _server = ConfigurationManager.AppSettings["PIMATIC.Server"];
            _port = ConfigurationManager.AppSettings["PIMATIC.Port"];
        }

        [TearDown]
        public void TearDown()
        {
            ConfigurationManager.AppSettings["PIMATIC.Username"] = _username;
            ConfigurationManager.AppSettings["PIMATIC.Password"] = _password;
            ConfigurationManager.AppSettings["PIMATIC.Server"] = _server;
            ConfigurationManager.AppSettings["PIMATIC.Port"] = _port;
        }

        [Test]
        [ExpectedPimaticException("E_PIM_SVC.002")]
        [TestCase("PIMATIC.Username")]
        [TestCase("PIMATIC.Password")]
        [TestCase("PIMATIC.Server")]
        [TestCase("PIMATIC.Port")]
        public void Given_AppSettingNotFound_ExpectedException(string appSetting)
        {
            ConfigurationManager.AppSettings[appSetting] = null;

            var port = PimaticSettings.Port;
            var server = PimaticSettings.Server;
            var password = PimaticSettings.Password;
            var username = PimaticSettings.Username;
        }

        [Test]
        [TestCase("PIMATIC.Username")]
        [TestCase("PIMATIC.Password")]
        [TestCase("PIMATIC.Server")]
        [TestCase("PIMATIC.Port")]
        public void Given_AppSettingFound_ExpectedAppSetting(string appSetting)
        {
            Assert.IsNotNull(PimaticSettings.Username);
            Assert.IsNotNull(PimaticSettings.Password);
            Assert.IsNotNull(PimaticSettings.Server);
            Assert.IsNotNull(PimaticSettings.Port);
        }
    }
}
