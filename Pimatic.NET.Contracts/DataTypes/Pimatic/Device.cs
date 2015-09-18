using System.Collections.Generic;

namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class Device
    {
        public string id { get; set; }
        public string deviceId { get; set; }
        public string name { get; set; }
        public string template { get; set; }
        public List<Attribute> attributes { get; set; }
        public List<object> actions { get; set; }
        public Config config { get; set; }
        public ConfigDefaults configDefaults { get; set; }
        public string @class { get; set; }
        public string attributeName { get; set; }
        public string attributeType { get; set; }
        public string attributeUnit { get; set; }
        public string command { get; set; }
        public int interval { get; set; }
        public List<Protocol> protocols { get; set; }
    }
}
