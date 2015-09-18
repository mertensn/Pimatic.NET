using System.Collections.Generic;

namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class Database
    {
        public List<DeviceAttributeLogging> deviceAttributeLogging { get; set; }
        public List<MessageLogging> messageLogging { get; set; }
    }
}