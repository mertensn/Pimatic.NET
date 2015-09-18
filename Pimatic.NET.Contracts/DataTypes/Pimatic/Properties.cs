namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class Properties
    {
        public Gpio gpio { get; set; }
        public Inverted inverted { get; set; }
        public Id id { get; set; }
        public Name name { get; set; }
        public Class @class { get; set; }
        public XLink xLink { get; set; }
        public XPresentLabel xPresentLabel { get; set; }
        public XAbsentLabel xAbsentLabel { get; set; }
    }
}