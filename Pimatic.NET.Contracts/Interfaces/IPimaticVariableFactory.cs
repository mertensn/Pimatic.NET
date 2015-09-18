using Pimatic.NET.Contracts.DataTypes.Messages;

namespace Pimatic.NET.Contracts.Interfaces
{
    public interface IPimaticVariableFactory
    {
        GetVariablesMessage GetVariables();
    }
}