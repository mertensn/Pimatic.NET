namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class Permissions
    {
        public string pages { get; set; }
        public string rules { get; set; }
        public string variables { get; set; }
        public string messages { get; set; }
        public string events { get; set; }
        public string devices { get; set; }
        public string groups { get; set; }
        public string plugins { get; set; }
        public string updates { get; set; }
        public string database { get; set; }
        public string config { get; set; }
        public bool controlDevices { get; set; }
        public bool restart { get; set; }
    }
}