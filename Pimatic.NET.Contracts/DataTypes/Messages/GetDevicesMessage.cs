using System.Collections.Generic;
using Pimatic.NET.Contracts.DataTypes.Pimatic;

namespace Pimatic.NET.Contracts.DataTypes.Messages
{
    public class GetDevicesMessage
    {
        public List<Device> devices { get; set; }
        public bool success { get; set; }
    }
}
