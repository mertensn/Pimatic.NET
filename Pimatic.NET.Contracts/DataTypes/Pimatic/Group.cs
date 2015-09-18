using System.Collections.Generic;

namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class Group
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<string> devices { get; set; }
        public List<object> rules { get; set; }
        public List<object> variables { get; set; }
    }
}