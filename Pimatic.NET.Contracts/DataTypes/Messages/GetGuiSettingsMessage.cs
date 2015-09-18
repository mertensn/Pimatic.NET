using Pimatic.NET.Contracts.DataTypes.Pimatic;

namespace Pimatic.NET.Contracts.DataTypes.Messages
{
    public class GetGuiSettingsMessage
    {
        public GuiSettings guiSettings { get; set; }
        public bool success { get; set; }
    }
}