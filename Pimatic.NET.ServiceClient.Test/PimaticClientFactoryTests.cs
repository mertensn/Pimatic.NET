using System;
using System.Linq;
using NUnit.Framework;
using Pimatic.NET.Contracts.DataTypes.Pimatic;
using Pimatic.NET.Contracts.Interfaces;
using Pimatic.NET.ServiceClient.Test.Attributes;

namespace Pimatic.NET.ServiceClient.Test
{
    [TestFixture]
    public class PimaticClientFactoryTests
    {
        IPimaticClientFactory _clientFactory;
        private string _testDeviceId;

        [SetUp]
        public void SetUp()
        {
            _clientFactory = new PimaticClientFactory();
            _testDeviceId = "dev_switch_test";
        }

        //TODO Nicolas Expand this test
        [Test]
        public void Given_GetConfig_ValidConfigIsReturned()
        {
            var config = _clientFactory.GetConfig();
            Assert.IsNotNull(config);
        }

        [Test]
        [Ignore]
        public void Given_DeviceAddedToConfig_ExpectsDeviceToBeAdded()
        {
            var firstDevice = _clientFactory.GetDevices().devices.FirstOrDefault();
            if (firstDevice == null) throw new NullReferenceException();

            _addDeviceToConfig(firstDevice.config);
            var addedDevice = _clientFactory.GetDeviceById(_testDeviceId);

            Assert.IsNotNull(addedDevice);
            Assert.AreEqual(addedDevice.device.id, _testDeviceId);

            Restart();
        }

        [Test]
        [Ignore]
        public void Given_RemoveDevice_DeviceIdRemoved()
        {
            _clientFactory.RemoveDevice(_testDeviceId);
            Restart();
        }

        [Test]
        [ExpectedPimaticException("E_PIM_SVC.001")]
        public void Given_AddDeviceByConfig_DuplicateDeviceIdProvided_ThrowsException()
        {
            var firstDevice = _clientFactory.GetDevices().devices.FirstOrDefault();
            if (firstDevice == null) throw new NullReferenceException();
            _clientFactory.AddDeviceByConfig(firstDevice.config);
        }

        [Test]
        [Ignore]
        public void Restart()
        {
            _clientFactory.Restart();
        }

        private void _addDeviceToConfig(Config config)
        {
            config.id = _testDeviceId;
            _clientFactory.AddDeviceByConfig(config);
        }
    }
}
