using System;
using System.Linq;
using NUnit.Framework;
using Pimatic.NET.Contracts.DataTypes.Pimatic;
using Pimatic.NET.Contracts.Interfaces;
using Pimatic.NET.ServiceClient.Factories;
using Pimatic.NET.ServiceClient.Test.Attributes;

namespace Pimatic.NET.ServiceClient.Test.Tests.Factories
{
    [TestFixture]
    public class PimaticDeviceFactoryTests
    {
        private IPimaticDeviceFactory _deviceFactory;
        private IPimaticVariableFactory _variableFactory;
        private string _testDeviceId;

        [SetUp]
        public void SetUp()
        {
            _deviceFactory = new PimaticDeviceFactory();
            _variableFactory = new PimaticVariableFactory();
            _testDeviceId = "dev_switch_test";
        }

        [Test]
        [Ignore]
        public void Given_DeviceAddedToConfig_ExpectsDeviceToBeAdded()
        {
            var firstDevice = _deviceFactory.GetDevices().devices.FirstOrDefault();
            if (firstDevice == null) throw new NullReferenceException();

            _addDeviceToConfig(firstDevice.config);
            var addedDevice = _deviceFactory.GetDeviceById(_testDeviceId);

            Assert.IsNotNull(addedDevice);
            Assert.AreEqual(addedDevice.device.id, _testDeviceId);
            Assert.AreEqual(addedDevice.device.actions, firstDevice.actions);
            Assert.AreEqual(addedDevice.device.attributes, firstDevice.attributes);
            Assert.AreEqual(addedDevice.device.config, firstDevice.config);
            Assert.AreEqual(addedDevice.device.configDefaults, firstDevice.configDefaults);
            Assert.AreEqual(addedDevice.device.name, firstDevice.name);
            Assert.AreEqual(addedDevice.device.template, firstDevice.template);
            Assert.IsTrue(addedDevice.success);
        }

        [Test]
        [ExpectedPimaticException("E_PIM_SVC.001")]
        public void Given_AddDeviceByConfig_DuplicateDeviceIdProvided_ThrowsException()
        {
            var firstDevice = _deviceFactory.GetDevices().devices.FirstOrDefault();
            if (firstDevice == null) throw new NullReferenceException();
            _deviceFactory.AddDeviceByConfig(firstDevice.config);
        }

        [Test]
        [Ignore]
        public void Given_RemoveDevice_DeviceIdRemoved()
        {
            _deviceFactory.RemoveDevice(_testDeviceId);
        }

        [Test]
        public void Given_GetDeviceClasses_ClassesReturned()
        {
            var classesMessage = _deviceFactory.GetDeviceClasses();

            Assert.IsNotNull(classesMessage.deviceClasses);
            Assert.Greater(classesMessage.deviceClasses.Count, 0);
            Assert.IsTrue(classesMessage.success);
        }

        [Test]
        public void Given_GetDeviceClassConfigSchema_ConfigSchemaReturned()
        {
            var firstClassName = _deviceFactory.GetDeviceClasses().deviceClasses.FirstOrDefault();
            var secondClassName = _deviceFactory.GetDeviceClasses().deviceClasses.Take(2).LastOrDefault();

            var getDeviceClassConfigSchemaMessageForFirstClassName = _deviceFactory.GetDeviceClassConfigSchema(firstClassName);
            var getDeviceClassConfigSchemaMessageForSecondClassName = _deviceFactory.GetDeviceClassConfigSchema(secondClassName);

            Assert.IsTrue(getDeviceClassConfigSchemaMessageForFirstClassName.success);
            Assert.IsTrue(getDeviceClassConfigSchemaMessageForSecondClassName.success);

            Assert.IsNotNull(getDeviceClassConfigSchemaMessageForFirstClassName.configSchema.title);
            Assert.IsNotNull(getDeviceClassConfigSchemaMessageForSecondClassName.configSchema.title);
        }

        [Test]
        [Ignore]
        public void Given_TurnOnAndOffDevice_CheckDeviceStatus()
        {
            var firstSwitchDevice = _deviceFactory.GetDevices().devices.FirstOrDefault(s => s.template == "switch");
            Assert.IsNotNull(firstSwitchDevice);

            var firstSwitchDeviceVariablesBeforeTurnOn = _variableFactory.GetVariables().variables.FirstOrDefault(s => s.name == firstSwitchDevice.id + ".state");
            Assert.IsNotNull(firstSwitchDeviceVariablesBeforeTurnOn);

            _deviceFactory.TurnOffDevice(firstSwitchDevice.id);
            _deviceFactory.TurnOnDevice(firstSwitchDevice.id);

            var firstSwitchDeviceVariablesAfterTurnOn = _variableFactory.GetVariables().variables.FirstOrDefault(s => s.name == "dev_switch1.state");
            Assert.IsNotNull(firstSwitchDeviceVariablesAfterTurnOn);
            Assert.IsTrue(Convert.ToBoolean(firstSwitchDeviceVariablesAfterTurnOn.value));

            if (!Convert.ToBoolean(firstSwitchDeviceVariablesBeforeTurnOn.value))
                _deviceFactory.TurnOffDevice(firstSwitchDevice.id);
        }

        private void _addDeviceToConfig(Config config)
        {
            config.id = _testDeviceId;
            _deviceFactory.AddDeviceByConfig(config);
        }
    }
}
