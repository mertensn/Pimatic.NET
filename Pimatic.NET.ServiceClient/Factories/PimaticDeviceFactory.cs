using System.Linq;
using Newtonsoft.Json;
using Pimatic.NET.Contracts.DataTypes.Exceptions;
using Pimatic.NET.Contracts.DataTypes.Messages;
using Pimatic.NET.Contracts.DataTypes.Pimatic;
using Pimatic.NET.Contracts.Interfaces;

namespace Pimatic.NET.ServiceClient.Factories
{
    /// <summary>
    /// Use this class to call the Pimatic REST Interface to execute Pimatic Device commands
    /// </summary>
    public class PimaticDeviceFactory : PimaticFactoryBase, IPimaticDeviceFactory
    {
        public Device AddDeviceByConfig(Config config)
        {
            if (GetDevices().devices.Any(s => s.id == config.id))
                throw new PimaticException("E_PIM_SVC.001", "Device with id {0} already exists in config file",
                    config.id);

            var addDeviceByConfigMessage = new AddDeviceByConfigMessage { deviceConfig = config };
            var response = PimaticRestClient.PerformHttpPost(addDeviceByConfigMessage, "/api/device-config");
            return JsonConvert.DeserializeObject<Device>(GetResultMessage(response));
        }

        public Device RemoveDevice(string deviceId)
        {
            CheckDevice(deviceId);
            var response = PimaticRestClient.PerformHttpDelete("/api/device-config/" + deviceId);
            return JsonConvert.DeserializeObject<Device>(GetResultMessage(response));
        }

        public GetDevicesMessage GetDevices()
        {
            var response = PimaticRestClient.PerformHttpGet("/api/devices");
            var devices = JsonConvert.DeserializeObject<GetDevicesMessage>(GetResultMessage(response));

            if (!devices.devices.Any() || devices.devices == null)
                throw new PimaticException("E_PIM_SVC.003", "No devices found");

            return devices;
        }

        public GetDeviceByIdMessage GetDeviceById(string deviceId)
        {
            var response = PimaticRestClient.PerformHttpGet("/api/devices/" + deviceId);
            var device = JsonConvert.DeserializeObject<GetDeviceByIdMessage>(GetResultMessage(response));
            if (device != null)
                if (device.device == null)
                    throw new PimaticException("E_PIM_SVC.005", "Device could not be found for deviceId {0}", deviceId);

            return device;
        }

        public GetDeviceClassesMessage GetDeviceClasses()
        {
            var response = PimaticRestClient.PerformHttpGet("/api/device-class");
            return JsonConvert.DeserializeObject<GetDeviceClassesMessage>(GetResultMessage(response));
        }

        public GetDeviceClassConfigSchemaMessage GetDeviceClassConfigSchema(string className)
        {
            var response = PimaticRestClient.PerformHttpGet("/api/device-class/" + className);
            return JsonConvert.DeserializeObject<GetDeviceClassConfigSchemaMessage>(GetResultMessage(response));
        }

        public TurnOnDeviceMessage TurnOnDevice(string deviceId)
        {
            CheckDevice(deviceId);
            var response = PimaticRestClient.PerformHttpGet("/api/device/" + deviceId + "/turnOn");
            return JsonConvert.DeserializeObject<TurnOnDeviceMessage>(GetResultMessage(response));
        }

        public TurnOffDeviceMessage TurnOffDevice(string deviceId)
        {
            CheckDevice(deviceId);
            var response = PimaticRestClient.PerformHttpGet("/api/device/" + deviceId + "/turnOff");
            return JsonConvert.DeserializeObject<TurnOffDeviceMessage>(GetResultMessage(response));
        }

        private void CheckDevice(string deviceId)
        {
            GetDeviceById(deviceId);
        }
    }
}