using System.Collections.Generic;

namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class Config
    {
        public string id { get; set; }
        public string name { get; set; }
        public string @class { get; set; }
        public string attributeName { get; set; }
        public string attributeType { get; set; }
        public string attributeUnit { get; set; }
        public string command { get; set; }
        public int interval { get; set; }
        public List<Protocol> protocols { get; set; }
        public List<Attribute2> attributes { get; set; }
        public Settings settings { get; set; }
        public List<Plugin> plugins { get; set; }
        public List<Device> devices { get; set; }
        public List<Rule> rules { get; set; }
        public List<Page> pages { get; set; }
        public List<Group> groups { get; set; }
        public List<User> users { get; set; }
        public List<Role> roles { get; set; }
        public List<object> variables { get; set; }
    }
}
