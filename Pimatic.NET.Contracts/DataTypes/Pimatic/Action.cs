namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class Action
    {
        public string description { get; set; }
        public string name { get; set; }
        public Params @params { get; set; }
        public Returns returns { get; set; }
    }
}
