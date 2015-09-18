using Pimatic.NET.Contracts.DataTypes.Messages;

namespace Pimatic.NET.Contracts.Interfaces
{
    public interface IPimaticCoreFactory
    {
        GetConfigMessage GetConfig();
        GetGuiSettingsMessage GetGuiSetttings();
        void Restart();
    }
}
