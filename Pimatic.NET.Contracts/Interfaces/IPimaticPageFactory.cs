using Pimatic.NET.Contracts.DataTypes.Messages;

namespace Pimatic.NET.Contracts.Interfaces
{
    public interface IPimaticPageFactory
    {
        GetPagesMessage GetPages();
        GetPageByIdMessage GetPageById(string pageId);
        AddDeviceToPageMessage AddDeviceToPage(string pageId, string deviceId);
        RemoveDeviceFromPageMessage RemoveDeviceFromPage(string pageId, string deviceId);
    }
}