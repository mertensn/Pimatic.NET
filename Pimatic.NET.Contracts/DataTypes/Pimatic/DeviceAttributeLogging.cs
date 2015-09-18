namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class DeviceAttributeLogging
    {
        public string deviceId { get; set; }
        public string attributeName { get; set; }
        public string type { get; set; }
        public string interval { get; set; }
        public string expire { get; set; }
    }
}