using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Pimatic.NET.Contracts.DataTypes.Exceptions;
using Pimatic.NET.Contracts.DataTypes.Messages;
using Pimatic.NET.Contracts.DataTypes.Pimatic;
using Pimatic.NET.Contracts.Interfaces;
using Config = Pimatic.NET.Contracts.DataTypes.Pimatic.Config;
using Device = Pimatic.NET.Contracts.DataTypes.Pimatic.Device;

namespace Pimatic.NET.ServiceClient
{
    /// <summary>
    /// Use this class to call the Pimatic REST Interface
    /// </summary>
    public class PimaticClientFactory : IPimaticClientFactory
    {
        //TODO NICOLAS Create Object for GetConfig
        public GetConfigMessage GetConfig()
        {
            var response = PimaticRestClient.PerformHttpGet("/api/config?password=" + PimaticSettings.Password);
            return JsonConvert.DeserializeObject<GetConfigMessage>(GetResultMessage(response));
        }

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
            var response = PimaticRestClient.PerformHttpDelete("/api/device-config/" + deviceId);
            return JsonConvert.DeserializeObject<Device>(GetResultMessage(response));
        }

        public void Restart()
        {
            var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
            PimaticRestClient.Login().PostAsync("http://" + PimaticSettings.Server + ":" + PimaticSettings.Port + "/api/restart", content);
        }

        public GetDevicesMessage GetDevices()
        {
            var response = PimaticRestClient.PerformHttpGet("/api/devices");
            return JsonConvert.DeserializeObject<GetDevicesMessage>(GetResultMessage(response));
        }

        public GetDeviceByIdMessage GetDeviceById(string deviceId)
        {
            var response = PimaticRestClient.PerformHttpGet("/api/devices/" + deviceId);
            return JsonConvert.DeserializeObject<GetDeviceByIdMessage>(GetResultMessage(response));
        }

        public GetDeviceClassesMessage GetDeviceClasses()
        {
            var response = PimaticRestClient.PerformHttpGet("/api/device-class");
            return JsonConvert.DeserializeObject<GetDeviceClassesMessage>(GetResultMessage(response));
        }

        private string GetResultMessage(HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
