using System.Collections.Generic;

namespace Pimatic.NET.Contracts.DataTypes.Messages
{
    public class GetDeviceClassesMessage
    {
        public List<string> deviceClasses { get; set; }
        public bool success { get; set; }
    }
}
