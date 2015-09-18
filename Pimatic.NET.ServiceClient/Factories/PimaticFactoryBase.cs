using System.Net.Http;

namespace Pimatic.NET.ServiceClient.Factories
{
    public class PimaticFactoryBase
    {
        protected string GetResultMessage(HttpResponseMessage response)
        {
           return response.Content.ReadAsStringAsync().Result;
        }
    }
}