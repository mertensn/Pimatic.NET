using System.Collections.Generic;

namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class ConfigDefaults
    {
        public string attributeName { get; set; }
        public string attributeType { get; set; }
        public string attributeUnit { get; set; }
        public string command { get; set; }
        public int interval { get; set; }
        public List<object> protocols { get; set; }
        public bool? forceSend { get; set; }
    }
}
