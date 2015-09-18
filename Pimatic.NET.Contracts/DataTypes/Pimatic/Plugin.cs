using System.Collections.Generic;

namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class Plugin
    {
        public string plugin { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        public string driver { get; set; }
        public DriverOptions driverOptions { get; set; }
        public int? receiverPin { get; set; }
        public int? transmitterPin { get; set; }
        public bool? debug { get; set; }
        public string apikey { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string device { get; set; }
        public string type { get; set; }
        public List<object> customOpenCommands { get; set; }
    }
}