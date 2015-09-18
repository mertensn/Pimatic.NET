using Newtonsoft.Json;
using Pimatic.NET.Contracts.DataTypes.Exceptions;
using Pimatic.NET.Contracts.DataTypes.Messages;
using Pimatic.NET.Contracts.Interfaces;

namespace Pimatic.NET.ServiceClient.Factories
{ 
    public class PimaticPageFactory : PimaticFactoryBase, IPimaticPageFactory
    {
        public GetPagesMessage GetPages()
        {
            var response = PimaticRestClient.PerformHttpGet("/api/pages");
            return JsonConvert.DeserializeObject<GetPagesMessage>(GetResultMessage(response));
        }

        public GetPageByIdMessage GetPageById(string pageId)
        {
            var response = PimaticRestClient.PerformHttpGet("/api/pages/" + pageId);
            var getPageByIdMessage = JsonConvert.DeserializeObject<GetPageByIdMessage>(GetResultMessage(response));
            if (getPageByIdMessage != null)
                if (getPageByIdMessage.page == null)
                    throw new PimaticException("E_PIM_SVC.004", "Page for pageId {0} could not be captured", pageId);

            return getPageByIdMessage;
        }

        public AddDeviceToPageMessage AddDeviceToPage(string pageId, string deviceId)
        {
            _checkPage(pageId);
            var response = PimaticRestClient.PerformHttpPost("/api/pages/" + pageId + "/devices/" + deviceId);
            return JsonConvert.DeserializeObject<AddDeviceToPageMessage>(GetResultMessage(response));
        }

        public RemoveDeviceFromPageMessage RemoveDeviceFromPage(string pageId, string deviceId)
        {
            _checkPage(pageId);
            var response = PimaticRestClient.PerformHttpDelete("/api/pages/" + pageId + "/devices/" + deviceId);
            return JsonConvert.DeserializeObject<RemoveDeviceFromPageMessage>(GetResultMessage(response));
        }

        private void _checkPage(string pageId)
        {
            GetPageById(pageId);
        }
    }
}