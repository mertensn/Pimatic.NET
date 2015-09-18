using Pimatic.NET.Contracts.DataTypes.Pimatic;

namespace Pimatic.NET.Contracts.DataTypes.Messages
{
    public class GetDeviceByIdMessage
    {
        public Device device { get; set; }
        public bool success { get; set; }
    }
}
