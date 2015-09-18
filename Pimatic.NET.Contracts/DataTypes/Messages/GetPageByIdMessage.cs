using Pimatic.NET.Contracts.DataTypes.Pimatic;

namespace Pimatic.NET.Contracts.DataTypes.Messages
{
    public class GetPageByIdMessage
    {
        public Page page { get; set; }
        public bool success { get; set; }
    }
}