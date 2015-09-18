using System.Collections.Generic;

namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class Page
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Device> devices { get; set; }
    }
}