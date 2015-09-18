using Pimatic.NET.Contracts.DataTypes.Pimatic;

namespace Pimatic.NET.Contracts.DataTypes.Messages
{
    public class GetDeviceClassConfigSchemaMessage
    {
        public ConfigSchema configSchema { get; set; }
        public bool success { get; set; }
    }
}