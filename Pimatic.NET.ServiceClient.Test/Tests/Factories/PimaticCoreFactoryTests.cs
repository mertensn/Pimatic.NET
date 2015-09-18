using System.Linq;
using NUnit.Framework;
using Pimatic.NET.Contracts.DataTypes;
using Pimatic.NET.Contracts.DataTypes.Messages;
using Pimatic.NET.Contracts.Interfaces;
using Pimatic.NET.ServiceClient.Factories;

namespace Pimatic.NET.ServiceClient.Test.Tests.Factories
{
    [TestFixture]
    public class PimaticCoreFactoryTests
    {
        private IPimaticCoreFactory _coreFactory;

        [SetUp]
        public void SetUp()
        {
            _coreFactory = new PimaticCoreFactory();
        }

        [Test]
        public void Given_GetConfig_ValidConfigIsReturned()
        {
            var configMessage = _coreFactory.GetConfig();

            Assert.IsNotNull(configMessage.config);
            Assert.IsNotNull(configMessage.config.users);
            Assert.IsNotNull(configMessage.config.users.FirstOrDefault());
            Assert.IsNotNull(configMessage.config.devices.FirstOrDefault());

            Assert.IsTrue(configMessage.success);
        }

        [Test]
        [Ignore]
        public void Restart()
        {
            _coreFactory.Restart();
        }

        [Test]
        public void Given_GetGuiSetttings_SettingsReturned()
        {
            var guiSettingsMessage = _coreFactory.GetGuiSetttings();

            Assert.IsTrue(guiSettingsMessage.success);
            Assert.IsNotNull(guiSettingsMessage.guiSettings);
        }
    }
}
