using System.Collections.Generic;

namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class ConfigSchema
    {
        public string title { get; set; }
        public string type { get; set; }
        public List<string> extensions { get; set; }
        public Properties properties { get; set; }
    }
}