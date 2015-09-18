using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Pimatic.NET.ServiceClient
{
    public static class PimaticRestClient
    {
        public static HttpClient Login()
        {
            var httpClient = new HttpClient();
            var content = new StringContent(_getJsonCredentials(), Encoding.UTF8, "application/json");
            var postResult = httpClient.PostAsync("http://" + PimaticSettings.Server + ":" + PimaticSettings.Port + "/login", content).Result;

            postResult.EnsureSuccessStatusCode();
            return httpClient;
        }

        public static HttpResponseMessage PerformHttpGet(string action)
        {
            return Login().GetAsync("http://" + PimaticSettings.Server + ":" + PimaticSettings.Port + action).Result;
        }

        public static HttpResponseMessage PerformHttpPost(object T, string action)
        {
            var jsonString = JsonConvert.SerializeObject(T);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var postResult = Login().PostAsync("http://" + PimaticSettings.Server + ":" + PimaticSettings.Port + action, content).Result;
            postResult.EnsureSuccessStatusCode();
            return null;
        }

        public static HttpResponseMessage PerformHttpPost(string action)
        {
            var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
            var postResult = Login().PostAsync("http://" + PimaticSettings.Server + ":" + PimaticSettings.Port + action, content).Result;
            postResult.EnsureSuccessStatusCode();
            return postResult;
        }

        public static HttpResponseMessage PerformHttpDelete(string action)
        {
            return Login().DeleteAsync("http://" + PimaticSettings.Server + ":" + PimaticSettings.Port + action).Result;
        }

        private static string _getJsonCredentials()
        {
            return "{\"username\":\"" + PimaticSettings.Username + "\"," +
                   "\"password\":\"" + PimaticSettings.Password + "\"}";
        }
    }
}
