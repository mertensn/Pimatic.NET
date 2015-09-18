using Pimatic.NET.Contracts.DataTypes.Pimatic;

namespace Pimatic.NET.Contracts.DataTypes.Messages
{
    public class GetConfigMessage
    {
        public Config config { get; set; }
        public bool success { get; set; }
    }
}
