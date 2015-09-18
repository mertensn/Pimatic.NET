using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Pimatic.NET.Contracts.DataTypes.Messages;
using Pimatic.NET.Contracts.Interfaces;

namespace Pimatic.NET.ServiceClient.Factories
{
    /// <summary>
    /// Use this class to call the Pimatic REST Interface to execute Pimatic Core commands
    /// </summary>
    public class PimaticCoreFactory : PimaticFactoryBase, IPimaticCoreFactory
    {
        public GetConfigMessage GetConfig()
        {
            var response = PimaticRestClient.PerformHttpGet("/api/config?password=" + PimaticSettings.Password);
            return JsonConvert.DeserializeObject<GetConfigMessage>(GetResultMessage(response));
        }

        public GetGuiSettingsMessage GetGuiSetttings()
        {
            var response = PimaticRestClient.PerformHttpGet("/api/config/settings/gui");
            return JsonConvert.DeserializeObject<GetGuiSettingsMessage>(GetResultMessage(response));
        }

        public void Restart()
        {
            var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
            PimaticRestClient.Login()
                .PostAsync("http://" + PimaticSettings.Server + ":" + PimaticSettings.Port + "/api/restart", content);
        }
    }
}
