using System.Collections.Generic;

namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class Attribute
    {
        public string description { get; set; }
        public string type { get; set; }
        public string label { get; set; }
        public bool discrete { get; set; }
        public string name { get; set; }
        public object value { get; set; }
        public List<History> history { get; set; }
        public object lastUpdate { get; set; }
        public List<string> labels { get; set; }
        public string unit { get; set; }
        public string acronym { get; set; }
    }
}
