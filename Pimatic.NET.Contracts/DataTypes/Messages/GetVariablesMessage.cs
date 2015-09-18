using System.Collections.Generic;
using Pimatic.NET.Contracts.DataTypes.Pimatic;

namespace Pimatic.NET.Contracts.DataTypes.Messages
{
    public class GetVariablesMessage
    {
        public List<Variable> variables { get; set; }
        public bool success { get; set; }
    }
}