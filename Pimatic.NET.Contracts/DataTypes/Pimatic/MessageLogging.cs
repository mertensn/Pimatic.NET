using System.Collections.Generic;

namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class MessageLogging
    {
        public string level { get; set; }
        public List<object> tags { get; set; }
        public string expire { get; set; }
    }
}