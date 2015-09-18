using Pimatic.NET.Contracts.DataTypes.Messages;
using Pimatic.NET.Contracts.DataTypes.Pimatic;

namespace Pimatic.NET.Contracts.Interfaces
{
    public interface IPimaticDeviceFactory
    {
        Device AddDeviceByConfig(Config config);
        GetDevicesMessage GetDevices();
        GetDeviceByIdMessage GetDeviceById(string deviceId);
        GetDeviceClassesMessage GetDeviceClasses();
        Device RemoveDevice(string deviceId);
        GetDeviceClassConfigSchemaMessage GetDeviceClassConfigSchema(string className);
        TurnOnDeviceMessage TurnOnDevice(string deviceId);
        TurnOffDeviceMessage TurnOffDevice(string deviceId);
    }
}
