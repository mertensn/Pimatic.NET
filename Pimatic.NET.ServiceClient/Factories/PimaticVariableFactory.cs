using Newtonsoft.Json;
using Pimatic.NET.Contracts.DataTypes.Messages;
using Pimatic.NET.Contracts.Interfaces;

namespace Pimatic.NET.ServiceClient.Factories
{
    /// <summary>
    /// Use this class to call the Pimatic REST Interface to execute Pimatic Variable commands
    /// </summary>
    public class PimaticVariableFactory : PimaticFactoryBase, IPimaticVariableFactory
    {
        public GetVariablesMessage GetVariables()
        {
            var response = PimaticRestClient.PerformHttpGet("/api/variables");
            return JsonConvert.DeserializeObject<GetVariablesMessage>(GetResultMessage(response));
        }
    }
}