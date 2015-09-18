namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class Variable
    {
        public string name { get; set; }
        public bool @readonly { get; set; }
        public string type { get; set; }
        public object value { get; set; }
        public string unit { get; set; }
    }
}