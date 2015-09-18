using System.Collections.Generic;
using Pimatic.NET.Contracts.DataTypes.Pimatic;

namespace Pimatic.NET.Contracts.DataTypes.Messages
{
    public class GetPagesMessage
    {
        public List<Page> pages { get; set; }
        public bool success { get; set; }
    }
}