namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class Rule
    {
        public string id { get; set; }
        public string name { get; set; }
        public string rule { get; set; }
        public bool active { get; set; }
        public bool logging { get; set; }
    }
}